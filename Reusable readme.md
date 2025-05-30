# <Feature Name>

## Summary

Brief explanation of the feature, its purpose, and when to use it.

## Setup

1. Required Unity version and packages (e.g., Input System)
2. Step-by-step instructions to set up the feature
3. Any assets or editor setup needed

## Scripts

### <MainScript>.cs
Describe what this script does, any key methods or public fields, and how it integrates into a scene.

### Optional:
- <HelperScript>.cs
- ExampleUsage.cs

## Usage

Example code block for integrating this into a project:

```csharp
void Update()
{
    if (InputManager.Instance.JumpPressed)
        Jump();

    Vector2 move = InputManager.Instance.MoveInput;
}