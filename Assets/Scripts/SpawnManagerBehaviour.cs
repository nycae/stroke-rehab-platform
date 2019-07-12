using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SpawnManagerBehaviour : MonoBehaviour
{
    [SerializeField]
    public GameObject ballClass;

    [SerializeField]
    public GameObject trashClass;

    [SerializeField]
    public GameObject[] spawnPoints;

    [SerializeField]
    public float waitTime = 0.5f;

    [SerializeField]
    public bool randomTrash = false;

    [SerializeField]
    UnityEngine.UI.Text logText;

    private float lastGoalTime;

    private bool isBallSpawned;

    private int lastBallIndex;

    private bool isGameOver = false;

    private void Start()
    {
        Assert.IsFalse(spawnPoints.Length <= 0);
    }

    private void Update()
    {
        if (!isBallSpawned
            &&
            !isGameOver
            &&
            (Time.time - lastGoalTime) >= waitTime)
        {
            SpawnBall();
            if (randomTrash) SpawnTrash();
        }
    }



    private void SpawnBall()
    {
        int ballIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(ballClass, spawnPoints[ballIndex].transform.position, Quaternion.identity);

        isBallSpawned = true;
        lastBallIndex = ballIndex;
    }

    private void SpawnTrash()
    {
        int trashIndex;

        do { trashIndex = Random.Range(0, spawnPoints.Length); }
        while (trashIndex == lastBallIndex);

        Instantiate(trashClass, spawnPoints[trashIndex].transform.position, Quaternion.identity);
    }

    public void OnGoal()
    {
        lastGoalTime = Time.time;
        isBallSpawned = false;
    }

    public void OnEndGame()
    {
        isGameOver = true;
    }

}
