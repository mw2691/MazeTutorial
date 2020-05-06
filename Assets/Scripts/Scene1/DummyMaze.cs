using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMaze : MonoBehaviour {

    public MazeCell CellPrefab;

    public MazeCellPassage PassagePrefab;

    public MazeCellWall WallPrefab;

    public MazeCellDoor DoorPrefab;

    void Start()
    {
        // the maze generation just fills a 20 x 20 grid with the prefabs defined above
        for (int x = 0; x < 20; x++)
        {
            for (int z = 0; z < 20; z++)
            {
                MazeCell cell = this.CreateCell(x, z);
                this.CreatePassage(cell, cell, MazeDirection.EAST);
                this.CreatePassage(cell, cell, MazeDirection.WEST);
                this.CreateWall(cell, cell, MazeDirection.NORTH);
                this.CreateWall(cell, cell, MazeDirection.SOUTH);
            }
        }

    }

    private MazeCell CreateCell(int x, int z)
    {
        MazeCell newCell = Instantiate(this.CellPrefab) as MazeCell;
        newCell.name = "Maze Cell " + x + ", " + z;
        newCell.transform.parent = this.transform;
        newCell.transform.localPosition = new Vector3(x - 20 * 0.5f + 0.5f, 0f, z - 20 * 0.5f + 0.5f);
        return newCell;
    }

    private void CreatePassage(MazeCell cell, MazeCell otherCell, MazeDirection direction)
    {
        MazeCellPassage prefab = direction == MazeDirection.EAST ? this.DoorPrefab : this.PassagePrefab;
        MazeCellPassage passage = Instantiate(prefab) as MazeCellPassage;
        passage.Initialize(cell, otherCell, direction);
    }

    private void CreateWall(MazeCell cell, MazeCell otherCell, MazeDirection direction)
    {
        MazeCellWall wall = Instantiate(this.WallPrefab) as MazeCellWall;
        wall.Initialize(cell, otherCell, direction);
    }
}
