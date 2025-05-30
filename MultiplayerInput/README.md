# Multiplayer Input (Unity Input System)

## Summary

This feature enables multiple players to control separate characters using Unity's Input System and PlayerInputManager.  
Each player prefab is automatically instantiated and manages its own inputs independently.

## Setup

1. Enable the Input System in Player Settings (if not already enabled).

2. Create or update the `PlayerInputActions` asset with a `Player` Action Map:
   - Actions: `Move` (Vector2), `Jump` (Button), `Interact` (Button)

3. Create a `Player` prefab:
   - Add a `PlayerInput` component
     - Set Behavior to `Send Messages` or `Invoke Unity Events`
     - Set Actions to your `PlayerInputActions` asset
   - Add a `PlayerInputHandler` script (provided here)

4. Add a `PlayerInputManager` to your scene:
   - Set the Player Prefab to your player prefab
   - Optionally adjust join behavior (e.g., Join on Button Press)

5. Add the `MultiplayerInputManager` script to an empty GameObject in the scene to handle basic lifecycle tracking.

## Scripts

### MultiplayerInputManager.cs

Tracks the number of connected players and their input states.

### PlayerInputHandler.cs

Handles per-player inputs via Unity Events.

## Usage

Each spawned player will move independently using their own input device. You can expand `PlayerInputHandler` to control a `CharacterController`, `Rigidbody`, etc.

## Extension Ideas

- Add player-specific UI and camera follow
- Assign player numbers/colors
- Add join/leave event handling
- Support local and remote players (networking)