using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVDetector : MonoBehaviour
{
    public enum Mode { Mode2D, Mode3D }

    [Header("Detection Settings")]
    public float viewRadius = 5f;
    [Range(0, 360)] public float viewAngle = 90f;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public Mode mode = Mode3D;
    public string requiredTag = "";

    [Header("Scan Settings")]
    public bool useScanCoroutine = false;
    public float scanInterval = 0.2f;

    [Header("Alert Integration (Optional)")]
    public AlertReceiver alertReceiver;

    [Header("Memory Settings")]
    public float memoryDuration = 2f;

    private float memoryTimer = 0f;


    [HideInInspector] public List<Transform> visibleTargets = new List<Transform>();

    void Start()
    {
        if (useScanCoroutine)
            StartCoroutine(ScanLoop());
    }

    void Update()
    {
        if (!useScanCoroutine)
        {
            FindVisibleTargets();
            UpdateAlertState();
        }
    }

    IEnumerator ScanLoop()
    {
        while (true)
        {
            FindVisibleTargets();
            UpdateAlertState();
            yield return new WaitForSeconds(scanInterval);
        }
    }

    public void FindVisibleTargets()
    {
        visibleTargets.Clear();

        Collider[] targetsInViewRadius = mode == Mode2D
            ? Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask)
            : Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        foreach (var col in targetsInViewRadius)
        {
            Transform target = col.transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                bool hitBlocked = mode == Mode2D
                    ? Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask)
                    : Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask);

                if (!hitBlocked)
                {
                    if (string.IsNullOrEmpty(requiredTag) || target.CompareTag(requiredTag))
                        visibleTargets.Add(target);
                }
            }
        }
    }

    void UpdateAlertState()
    {
        if (alertReceiver == null) return;

        if (visibleTargets.Count > 0)
        {
            memoryTimer = memoryDuration;
            alertReceiver.Alert(visibleTargets[0]);
        }
        else if (memoryTimer > 0f)
        {
            memoryTimer -= useScanCoroutine ? scanInterval : Time.deltaTime;
            if (memoryTimer <= 0f)
            {
                alertReceiver.ClearAlert();
            }
        }
    }


    public Vector3 DirFromAngle(float angleDegrees)
    {
        angleDegrees += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angleDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleDegrees * Mathf.Deg2Rad));
    }
}
