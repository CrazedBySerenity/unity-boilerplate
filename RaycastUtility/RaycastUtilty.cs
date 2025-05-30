public static class RaycastUtility
{
    // --- 2D Raycasting ---

    /// <summary>
    /// Returns true if there's no collider between origin and target in 2D.
    /// </summary>
    public static bool HasLineOfSight2D(Vector2 origin, Vector2 target, LayerMask mask)
    {
        RaycastHit2D hit = Physics2D.Linecast(origin, target, mask);
        return hit.collider == null;
    }

    /// <summary>
    /// Returns GameObject if 2D ray hits an object with the specified tag.
    /// </summary>
    public static GameObject RaycastToTag2D(Vector2 origin, Vector2 direction, float distance, string tag)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance);
        return hit.collider != null && hit.collider.CompareTag(tag) ? hit.collider.gameObject : null;
    }

    // --- 3D Raycasting ---

    /// <summary>
    /// Returns true if there's no collider between origin and target in 3D.
    /// </summary>
    public static bool HasLineOfSight3D(Vector3 origin, Vector3 target, LayerMask mask)
    {
        Vector3 direction = (target - origin).normalized;
        float distance = Vector3.Distance(origin, target);
        return !Physics.Raycast(origin, direction, distance, mask);
    }

    /// <summary>
    /// Returns GameObject if 3D ray hits an object with the specified tag.
    /// </summary>
    public static GameObject RaycastToTag3D(Vector3 origin, Vector3 direction, float distance, string tag)
    {
        if (Physics.Raycast(origin, direction, out RaycastHit hit, distance))
        {
            return hit.collider.CompareTag(tag) ? hit.collider.gameObject : null;
        }
        return null;
    }
}
