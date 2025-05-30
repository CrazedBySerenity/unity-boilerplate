# Field of View Detector (2D and 3D)

## Summary

This feature provides a reusable field-of-view (FOV) detection system for AI agents.  
It detects targets within a radius and viewing angle, with optional line-of-sight checks via raycasts.

Supports both 2D and 3D modes with minimal setup.

## Setup

1. Add the `FOVDetector.cs` component to your AI/NPC GameObject.
2. Configure detection range, angle, and target layer mask.
3. Optionally assign a tag to filter detected objects.
4. Call `GetVisibleTargets()` or use `visibleTargets` in your AI logic.

## Scripts

### FOVDetector.cs

- `viewRadius`: max detection distance
- `viewAngle`: cone angle (in degrees)
- `targetMask`: which layers count as valid targets
- `obstacleMask`: which layers can block vision
- `visibleTargets`: updated list of detected targets

### FOVVisualizer.cs (optional)

Draws the field of view cone and rays in the Scene view for debugging.

### Scan Settings

- `useScanCoroutine`: If enabled, runs detection every `scanInterval` seconds instead of every frame
- `scanInterval`: Time in seconds between each scan

### Alert Integration

- Assign an `AlertReceiver` (from the AlertSystem/) to trigger alert state changes
- Works with both coroutine and Update modes

```csharp
fov.alertReceiver = GetComponent<AlertReceiver>();


## Example

```csharp
void Update()
{
    foreach (var target in fov.visibleTargets)
    {
        Debug.Log("Target in view: " + target.name);
    }
}
