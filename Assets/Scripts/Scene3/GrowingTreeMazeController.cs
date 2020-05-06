using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingTreeMazeController : MonoBehaviour {
    // remember to assign the necessary prefabs for cells, passages etc.
    public GrowingTreeMaze MazePrefab;

    private GrowingTreeMaze MazeInstance;

    void Start()
    {
        this.BeginGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.RestartGame();
        }
    }

    private void BeginGame()
    {
        this.MazeInstance = GameObject.Instantiate(this.MazePrefab) as GrowingTreeMaze;
        StartCoroutine(this.MazeInstance.Generate());
    }

    private void RestartGame()
    {
        StopAllCoroutines();
        GameObject.Destroy(this.MazeInstance.gameObject);
        this.BeginGame();
    }
}
