using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(FOVDetector))]
public class FOVVisualizer : MonoBehaviour
{
    public Color visionColor = Color.yellow;

    void OnDrawGizmos()
    {
        FOVDetector fov = GetComponent<FOVDetector>();
        Gizmos.color = visionColor;

        Vector3 origin = transform.position;
        Vector3 left = Quaternion.Euler(0, -fov.viewAngle / 2, 0) * transform.forward;
        Vector3 right = Quaternion.Euler(0, fov.viewAngle / 2, 0) * transform.forward;

        Gizmos.DrawWireSphere(origin, fov.viewRadius);
        Gizmos.DrawLine(origin, origin + left * fov.viewRadius);
        Gizmos.DrawLine(origin, origin + right * fov.viewRadius);
    }
}
