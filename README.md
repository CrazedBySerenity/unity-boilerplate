# Unity Reusable Feature Library

## Overview

This repository contains a collection of modular, reusable Unity features designed for rapid prototyping and scalable game development.  
Each feature is organized into its own folder with scripts, setup instructions, and optional integration points.

All features are designed to work:
- **Independently**, as drop-in modules
- **Together**, for more complex systems (e.g., Patrol + Detection + Alert)

## Features

| Feature          | Description                                      | Status      |
|------------------|--------------------------------------------------|-------------|
| Input            | Centralized input manager for Unity Input System | ✅ Complete |
| Raycast Utility  | Static helpers for 2D and 3D raycasts             | ✅ Complete |
| Patrol System    | Waypoint-based movement with wait, ping-pong, pathfinding support | ✅ Complete |
| Field of View    | 2D/3D vision cone with obstacle and angle checks  | ✅ Complete |
| Alert System     | Tracks alert/passive state and integrates with detection or patrol | ✅ Complete |

> See each folder’s `README.md` for setup, examples, and integration notes.

## How to Use

1. Clone or download this repository
2. Drop any folder (e.g. `Patrol/`, `Input/`) into your Unity project
3. Follow the instructions in that feature’s `README.md`
4. Customize or extend to fit your project’s needs

## Integration Examples

Combine features easily:

- **Patrolling Guard with Detection**:
  - Add `PatrolAgent` to NPC
  - Add `FOVDetector` and link it to `AlertReceiver`
  - On detection, patrol is interrupted

- **Static Camera with Alert Zones**:
  - Use `FOVDetector` without patrol
  - Trigger `AlertReceiver` on detection

## Compatibility

- NOT TESTED YET
- A* Pathfinding Project support (optional)
- NavMesh Agent support (optional)

## License

MIT License. See `LICENSE` file for details.
