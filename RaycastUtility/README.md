# Raycast Utility (2D and 3D)

## Summary

This utility provides reusable static methods for common raycasting operations in both 2D and 3D.  
It is ideal for AI visibility checks, environmental sensing, or tag-based hit detection.

## Setup

1. No special setup is needed.
2. Add the `RaycastUtility.cs` script to your project.
3. Call the static methods from any script to perform 2D or 3D raycasts.

## Scripts

### RaycastUtility.cs

Contains the following methods:

#### 2D Methods
- `bool HasLineOfSight2D(Vector2 origin, Vector2 target, LayerMask mask)`
- `GameObject RaycastToTag2D(Vector2 origin, Vector2 direction, float distance, string tag)`

#### 3D Methods
- `bool HasLineOfSight3D(Vector3 origin, Vector3 target, LayerMask mask)`
- `GameObject RaycastToTag3D(Vector3 origin, Vector3 direction, float distance, string tag)`

## Usage

### Line of Sight (2D)

```csharp
if (RaycastUtility.HasLineOfSight2D(transform.position, player.position, obstacleMask))
{
    Debug.Log("Clear line of sight (2D)");
}

### RaycastVisualizer.cs

Attach this to any GameObject to visualize a 2D or 3D raycast in the Scene view.

#### Inspector Fields:
- `RayType` — choose 2D or 3D mode
- `Direction` — the direction of the ray
- `Distance` — how far the ray extends
- `LayerMask` — what layers to include in detection
- `RequiredTag` — optional tag filtering
- `Hit/Miss Color` — for drawing the ray line

Example use: debugging AI vision, sensor checks, or tag-specific detection.

Note: This only draws in the Scene view, not during gameplay.
