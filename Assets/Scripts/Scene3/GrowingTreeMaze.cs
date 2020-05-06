using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingTreeMaze : MonoBehaviour {

    public CellVector size;

    public MazeCell CellPrefab;

    public MazeCellPassage PassagePrefab;

    public MazeCellWall WallPrefab;

    public MazeCellDoor DoorPrefab;

    [Range(0f, 1f)]
    public float doorProbability;
    // use this as the waiting interval during the maze creation
    public float CreationStepDelay;

    private MazeCell[,] cells;
    // the actual implementation of the growing tree
    public IEnumerator Generate(PlayerController PlayerPrefab = null, Goal GoalPrefab = null)
    {
        this.cells = new MazeCell[size.x, size.z];
        // 1st step: create a list cells
        List<MazeCell> activeCells = new List<MazeCell>();
        // 2nd step: add a first cell
        this.DoFirstGenerationStep(activeCells);
        // 3rd - 5th step: add neighbors and remove cells until the list is empty
        // TODO: implement the main loop and pause for one frame in each step so you can see how the maze grows
        
        if (PlayerPrefab && GoalPrefab)
        {
            // TODO: Fourth scene: If those prefabs are assigned, i.e. !null, than they should be initialized here.
            // First, the goal should be placed in the center of the maze. Second, the player, should be placed
            // randomly on the outskirts of the maze.
        }

        yield return null;
    }

    private void DoFirstGenerationStep(List<MazeCell> activeCells)
    {
        // TODO: create a new cell at the center of the maze
    }
    
    private void DoNextGenerationStep(List<MazeCell> activeCells)
    {
        // TODO: implement the maze generation
        // 1st: get the index of the cell you want to work with, lets take the last one in the list
        int currentIndex = -1;
        MazeCell currentCell = activeCells[currentIndex];
        // if the cell has already all walls and connections, we do not want to change it anymore
        if (currentCell.IsFullyInitialized)
        {
            // TODO: the cell should be removed from the list
            return;
        }
        // TODO: we need to find the next edge (north, east, south, or west), we want to connect. Change this to a random direction,
        // there is a convenient method for this defined in MazeCell
        MazeDirection direction = MazeDirection.NORTH;
        // TODO: determine the new coordinates, have a look into the MazeDirections class on how to obtain CellVector from a direction
        CellVector coordinates = new CellVector(0, 0);
        // TODO: if the coordinates are valid, we might add a new cell, otherwise we create a wall (see functions below)
        if (ContainsCoordinates(coordinates))
        {
            // TODO: fetch the cell, if its null, create a cell, add a passage (see functions below), and add the cell to the list; create a wall otherwise
            MazeCell neighbor = this.GetCellAt(coordinates);
        }
        else
        {
            // TODO: create a wall
        }
    }

    private MazeCell CreateCell(CellVector coordinates)
    {
        MazeCell newCell = Instantiate(this.CellPrefab) as MazeCell;
        cells[coordinates.x, coordinates.z] = newCell;
        newCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
        newCell.coordinates = coordinates;
        // we create a hierarchy where each cell is a child of the gameobject with the GrowingTreeMaze script
        newCell.transform.parent = this.transform;
        newCell.transform.localPosition = new Vector3(coordinates.x - this.size.x * 0.5f + 0.5f, 0f, coordinates.z - this.size.z * 0.5f + 0.5f);
        return newCell;
    }

    private void CreatePassage(MazeCell cell, MazeCell otherCell, MazeDirection direction)
    {
        // we chose randomly if we create a wall or a door
        MazeCellPassage prefab = Random.value < doorProbability ? this.DoorPrefab : this.PassagePrefab;
        MazeCellPassage passage = Instantiate(prefab) as MazeCellPassage;
        passage.Initialize(cell, otherCell, direction);
        passage = Instantiate(prefab) as MazeCellPassage;
        passage.Initialize(otherCell, cell, direction.GetOpposite());
    }

    private void CreateWall(MazeCell cell, MazeCell otherCell, MazeDirection direction)
    {
        MazeCellWall wall = Instantiate(this.WallPrefab) as MazeCellWall;
        wall.Initialize(cell, otherCell, direction);
        if (otherCell != null)
        {
            wall = Instantiate(this.WallPrefab) as MazeCellWall;
            wall.Initialize(otherCell, cell, direction.GetOpposite());
        }
    }

    public bool ContainsCoordinates(CellVector coordinate)
    {
        // TODO: implement this check
        return false;
    }

    private MazeCell GetCellAt(CellVector coordinates)
    {
        return this.cells[coordinates.x, coordinates.z];
    }
}
