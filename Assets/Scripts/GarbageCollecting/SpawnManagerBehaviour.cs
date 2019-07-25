using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SpawnManagerBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject ballClass;

    [SerializeField]
    private GameObject trashClass;

    [SerializeField]
    private GameObject[] spawnPoints;

    [SerializeField]
    private float waitTime = 0.5f;

    [SerializeField]
    private bool randomTrash = false;

    [SerializeField]
    private GameObject trash;

    private float lastGoalTime;

    private bool isBallSpawned = false;

    private int lastBallIndex = 0;

    private bool isGameOver = false;

    private void Start()
    {
        Assert.IsFalse(spawnPoints.Length <= 0);
        StoreBall.OnGoal += AttendGoal;
        ScoreManager.OnGameEnd += AttendEndGame;
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

        trash = Instantiate(trashClass, spawnPoints[trashIndex].transform.position, Quaternion.identity);
    }

    public void AttendGoal()
    {
        lastGoalTime = Time.time;
        if (randomTrash)
        {
            Destroy(trash);
            SpawnTrash();
        }
        isBallSpawned = false;
    }

    public void AttendEndGame()
    {
        isGameOver = true;
    }

}
