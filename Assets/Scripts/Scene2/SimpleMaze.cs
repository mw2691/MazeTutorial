using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMaze : MonoBehaviour {

    public CellVector size;

    public MazeCell CellPrefab;

    public float CreationStepDelay;

    private MazeCell[,] cells;

    void Start () {
        // TODO: start the Generate coroutine
	}

    public IEnumerator Generate()
    {
        // TODO: add a delay to pause after each cell generation
        this.cells = new MazeCell[this.size.x, this.size.z];
        CellVector coordinates = this.RandomCoordinates;
        // TODO: implement the ContainsCoordinates check
        while (this.ContainsCoordinates(coordinates) && this.GetCellAt(coordinates) == null)
        {
            this.CreateCell(coordinates);
            coordinates += MazeDirections.RandomValue.ToCellVector();
        }

        yield return null;
    }

    private MazeCell GetCellAt(CellVector coordinates)
    {
        return this.cells[coordinates.x, coordinates.z];
    }

    private MazeCell CreateCell(CellVector coordinates)
    {
        MazeCell newCell = Instantiate(this.CellPrefab) as MazeCell;
        cells[coordinates.x, coordinates.z] = newCell;
        newCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
        newCell.coordinates = coordinates;
        newCell.transform.parent = this.transform;
        newCell.transform.localPosition = new Vector3(coordinates.x - this.size.x * 0.5f + 0.5f, 0f, coordinates.z - this.size.z * 0.5f + 0.5f);
        return newCell;
    }

    public CellVector RandomCoordinates
    {
        get
        {
            return new CellVector(Random.Range(0, this.size.x), Random.Range(0, this.size.z));
        }
    }

    public bool ContainsCoordinates(CellVector coordinate)
    {
        // TODO: implement this check
        return false;
    }
}
