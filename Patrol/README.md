# Patrol System (2D and 3D)

## Summary

This feature provides a simple, reusable patrol behavior for NPCs in both 2D and 3D projects.  
NPCs move between waypoints with smooth movement and flexible logic. It supports direct movement, Unity NavMesh, and A* Pathfinding Project.

## Setup

1. Create an empty GameObject and add the `PatrolPath` script to it.
2. Add child Transforms to that GameObject — these become patrol points.
3. Create a GameObject for your NPC and add the `PatrolAgent` script.
4. Assign the `PatrolPath` reference in the Inspector.
5. Choose 2D or 3D mode, and optionally configure speed, delay, and behavior.

## Scripts

### `PatrolPath.cs`

- Automatically collects all child transforms as patrol points.
- Can be shared between multiple agents.

### `PatrolAgent.cs`

Moves the agent between waypoints with optional waiting, ping-pong direction, pathfinding support, and delays.

#### Core settings:
- `speed`: movement speed
- `stoppingDistance`: how close to get before switching to the next point
- `mode`: 2D or 3D movement
- `patrolDirection`: Loop or PingPong (reverse direction at ends)

## Usage Example

```csharp
// Example setup in script
agent.waitTimeAtPoint = 2f;
agent.useRandomWaitTime = true;
agent.minWaitTime = 1f;
agent.maxWaitTime = 3f;
agent.patrolDirection = PatrolAgent.PatrolDirection.PingPong;
agent.stopAtEnd = false;

### Optional: NavMesh or A* Support

This system will automatically use Unity’s `NavMeshAgent` or the A* Pathfinding Project’s `AIPath` component **if either is present on the agent**.  
No extra configuration is required — the `PatrolAgent` script will detect and use whichever is available.

#### Supported Components
- `NavMeshAgent` — Unity's built-in NavMesh system
- `AIPath` — From the A* Pathfinding Project (https://arongranberg.com/astar)

If neither is present, the script falls back to manual `transform.position` movement.

#### Requirements

**For NavMesh:**
- Ensure you’ve baked a NavMesh via Unity’s Navigation window
- Place patrol points and agents on walkable surfaces
- Add a `NavMeshAgent` component to your NPC

### NavMesh Setup (Unity built-in)

1. Open the **Navigation** window via `Window → AI → Navigation`.
2. Select the GameObjects you want to be walkable (e.g., ground, floor).
3. In the Inspector, mark them as **Static**, then go to the **Navigation** window and check **Navigation Static**.
4. In the **Bake** tab, click **Bake** to generate the NavMesh.
5. Add a `NavMeshAgent` component to your NPC.
6. Adjust the agent’s speed, stopping distance, and other properties as needed.
7. Ensure your patrol points are placed on walkable NavMesh surfaces.


**For A\* Pathfinding:**
- Import the A* Pathfinding Project package
- Define a graph (e.g., Grid Graph) in your scene
- Add an `AIPath` component and optional `Seeker` to your NPC

### A* Pathfinding Setup (Aron Granberg’s A* Project)

1. Download and install the **A\*** Pathfinding Project from the Asset Store or [arongranberg.com/astar](https://arongranberg.com/astar).
2. In your scene, create an empty GameObject and name it `AStar`.
3. Add the `Pathfinder` component (automatically added when you open the A* Inspector).
4. Open the **A\*** Inspector via `Window → A* Pathfinding Project → A* Inspector`.
5. In the A* Inspector, create a **Grid Graph** (or other graph type) and scale/position it to fit your scene.
6. Press **Scan** to generate the pathfinding data.
7. On your NPC, add the following components:
   - `Seeker`
   - `AIPath`
8. Configure `AIPath` options like speed, acceleration, and end-reached distance.
9. Confirm that your patrol points are located on walkable areas within the graph.
