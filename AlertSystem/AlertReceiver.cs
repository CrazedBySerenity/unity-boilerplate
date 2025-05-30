using UnityEngine;
using UnityEngine.Events;

public class AlertReceiver : MonoBehaviour
{
    [Header("Alert Events")]
    public UnityEvent<Transform> OnAlerted;
    public UnityEvent OnLostTarget;

    [Header("Linked Systems (Optional)")]
    public MonoBehaviour patrolAgentScript; // Reference to PatrolAgent if used

    public AlertState State { get; private set; } = AlertState.Passive;
    public Transform Target { get; private set; }

    public void Alert(Transform target)
    {
        if (State != AlertState.Alerted)
        {
            State = AlertState.Alerted;
            Target = target;
            OnAlerted?.Invoke(target);

            if (patrolAgentScript != null)
                patrolAgentScript.enabled = false;
        }
    }

    public void ClearAlert()
    {
        if (State == AlertState.Alerted)
        {
            State = AlertState.Passive;
            Target = null;
            OnLostTarget?.Invoke();

            if (patrolAgentScript != null)
                patrolAgentScript.enabled = true;
        }
    }
}
