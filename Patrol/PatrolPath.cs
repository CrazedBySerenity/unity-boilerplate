using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    public Transform[] GetWaypoints()
    {
        int count = transform.childCount;
        Transform[] waypoints = new Transform[count];
        for (int i = 0; i < count; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
        return waypoints;
    }
}
