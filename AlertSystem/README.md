# Alert System (Modular AI Alert State)

## Summary

This feature manages an AI's alert state (e.g., passive, suspicious, alert) based on inputs from other systems such as field-of-view detection or triggers.

It works standalone or integrates with:
- `FOVDetector.cs` (from DetectionFOV/)
- `PatrolAgent.cs` (from Patrol/)

## Setup

1. Add `AlertReceiver.cs` to any NPC or AI object.
2. Optionally assign a reference to a `PatrolAgent` or other controller to pause/resume movement on alert.
3. From a detection system (e.g., `FOVDetector`), call `receiver.Alert(target)` and `receiver.ClearAlert()`.

## Alert Levels

- `Passive`: no target detected
- `Alerted`: target detected
- `Investigating` (optional extension)

## Example Integration

```csharp
if (visibleTargets.Count > 0)
    alertReceiver.Alert(visibleTargets[0]);
else
    alertReceiver.ClearAlert();
