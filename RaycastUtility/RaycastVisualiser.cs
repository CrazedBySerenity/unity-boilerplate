using UnityEngine;

public class RaycastVisualizer : MonoBehaviour
{
    public enum RayType { Raycast2D, Raycast3D }

    [Header("Common")]
    public RayType rayType = RayType.Raycast2D;
    public Vector3 direction = Vector3.right;
    public float distance = 5f;
    public Color hitColor = Color.red;
    public Color missColor = Color.green;
    public string requiredTag = "";
    public LayerMask mask = ~0;

    private void OnDrawGizmos()
    {
        if (rayType == RayType.Raycast2D)
        {
            Vector2 origin2D = transform.position;
            RaycastHit2D hit = Physics2D.Raycast(origin2D, direction, distance, mask);

            Gizmos.color = (hit.collider != null && (string.IsNullOrEmpty(requiredTag) || hit.collider.CompareTag(requiredTag)))
                ? hitColor
                : missColor;

            Vector2 end = hit.collider ? hit.point : origin2D + (Vector2)direction.normalized * distance;
            Gizmos.DrawLine(origin2D, end);
        }
        else
        {
            Vector3 origin3D = transform.position;
            bool didHit = Physics.Raycast(origin3D, direction, out RaycastHit hit, distance, mask);

            Gizmos.color = (didHit && (string.IsNullOrEmpty(requiredTag) || hit.collider.CompareTag(requiredTag)))
                ? hitColor
                : missColor;

            Vector3 end = didHit ? hit.point : origin3D + direction.normalized * distance;
            Gizmos.DrawLine(origin3D, end);
        }
    }
}
