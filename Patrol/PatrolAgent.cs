using UnityEngine;
#if UNITY_AI_NAVIGATION
using UnityEngine.AI;
#endif
#if ASTAR_PATHFINDING_PROJECT
using Pathfinding;
#endif

public class PatrolAgent : MonoBehaviour
{
    public enum PatrolMode { Mode2D, Mode3D }
    public enum PatrolDirection { Loop, PingPong }

    [Header("References")]
    public PatrolPath path;

    [Header("Movement Settings")]
    public float speed = 2f;
    public float stoppingDistance = 0.2f;
    public PatrolMode mode = PatrolMode.Mode2D;
    public PatrolDirection patrolDirection = PatrolDirection.Loop;
    public bool stopAtEnd = false;
    public float startDelay = 0f;

    [Header("Wait Settings")]
    public float waitTimeAtPoint = 0f;
    public bool useRandomWaitTime = false;
    public float minWaitTime = 1f;
    public float maxWaitTime = 3f;

    private Transform[] waypoints;
    private int currentIndex = 0;
    private int direction = 1;
    private bool isWaiting = false;
    private bool isStopped = false;
    private float waitTimer = 0f;
    private float startDelayTimer = 0f;

#if UNITY_AI_NAVIGATION
    private NavMeshAgent navAgent;
#endif
#if ASTAR_PATHFINDING_PROJECT
    private AIPath aiPath;
#endif

    void Start()
    {
        if (path != null)
        {
            waypoints = path.GetWaypoints();
            startDelayTimer = startDelay;
        }

#if UNITY_AI_NAVIGATION
        navAgent = GetComponent<NavMeshAgent>();
#endif
#if ASTAR_PATHFINDING_PROJECT
        aiPath = GetComponent<AIPath>();
#endif
    }

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0 || isWaiting || isStopped)
            return;

        if (startDelayTimer > 0f)
        {
            startDelayTimer -= Time.deltaTime;
            return;
        }

        Vector3 target = waypoints[currentIndex].position;

        // A* support
#if ASTAR_PATHFINDING_PROJECT
        if (aiPath != null)
        {
            aiPath.destination = target;
            if (!aiPath.pathPending && aiPath.reachedDestination)
                HandleWaypointArrival();
            return;
        }
#endif

        // NavMesh support
#if UNITY_AI_NAVIGATION
        if (navAgent != null)
        {
            if (navAgent.destination != target)
                navAgent.SetDestination(target);

            if (!navAgent.pathPending && navAgent.remainingDistance <= stoppingDistance)
                HandleWaypointArrival();

            return;
        }
#endif

        // Manual movement fallback
        Vector3 current = transform.position;
        Vector3 directionVec = (target - current).normalized;
        transform.position += directionVec * speed * Time.deltaTime;

        if (Vector3.Distance(current, target) <= stoppingDistance)
        {
            HandleWaypointArrival();
        }
    }

    void LateUpdate()
    {
        if (!isWaiting) return;
        waitTimer -= Time.deltaTime;
        if (waitTimer <= 0f)
            isWaiting = false;
    }

    private void HandleWaypointArrival()
    {
        if (useRandomWaitTime)
            waitTimer = Random.Range(minWaitTime, maxWaitTime);
        else
            waitTimer = waitTimeAtPoint;

        isWaiting = waitTimer > 0f;

        if (stopAtEnd && currentIndex == waypoints.Length - 1)
        {
            isStopped = true;
            return;
        }

        if (patrolDirection == PatrolDirection.Loop)
        {
            currentIndex = (currentIndex + 1) % waypoints.Length;
        }
        else // PingPong
        {
            currentIndex += direction;

            if (currentIndex >= waypoints.Length || currentIndex < 0)
            {
                direction *= -1;
                currentIndex += direction * 2;
            }
        }
    }
}
