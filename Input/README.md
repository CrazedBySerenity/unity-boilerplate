# Input System (Unity Input System)

## Summary

This folder provides a reusable `InputManager` using Unity's Input System.  
It centralizes input handling so that movement and action inputs can be accessed from anywhere in your project.

## Setup

1. Enable Unity's Input System:
   - Edit → Project Settings → Player → Active Input Handling → Input System Package (New)

2. Create an Input Actions asset:
   - Right-click in the Project window → Create → Input Actions → Name it `PlayerInputActions`
   - Open the asset and create an Action Map called `Player`
   - Add these actions:
     - `Move` (Value, Vector2) — bind to WASD and Gamepad Left Stick
     - `Jump` (Button) — bind to Space and Gamepad A
     - `Interact` (Button) — bind to E and Gamepad X
   - Save the asset

3. Auto-generate the C# wrapper:
   - Select the `PlayerInputActions` asset in the Inspector
   - Check "Generate C# Class" and name it `PlayerInputActions`
   - Click Apply

## Scripts

### InputManager.cs

Wraps Unity’s `PlayerInputActions` input class into a singleton manager with simple access to common actions:

- `MoveInput` → `Vector2` movement vector
- `JumpPressed` → `bool` for jump trigger
- `InteractPressed` → `bool` for interaction trigger

Place this script on a GameObject called `InputManager` in your initial scene. It will persist between scenes.

## Usage

Example usage inside any script:

```csharp
void Update()
{
    var input = InputManager.Instance;

    if (input.JumpPressed)
        Jump();

    Vector2 move = input.MoveInput;
}