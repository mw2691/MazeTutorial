using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerWithPlayer : MonoBehaviour {

    public GrowingTreeMaze MazePrefab;

    public PlayerController PlayerPrefab;

    public Goal GoalPrefab;

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
        StartCoroutine(this.MazeInstance.Generate(this.PlayerPrefab, this.GoalPrefab));
    }

    public void RestartGame()
    {
        StopAllCoroutines();
        GameObject.Destroy(this.MazeInstance.gameObject);
        this.BeginGame();
    }
}
