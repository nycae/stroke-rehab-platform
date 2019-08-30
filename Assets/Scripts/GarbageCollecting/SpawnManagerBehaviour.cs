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
    private GameObject trash;

    [SerializeField]
    private float waitTime = 0.5f;

    [SerializeField]
    private bool randomTrash = false;

    private int lastBallIndex = 0;

    private bool isGameOver = false;

    private void Start()
    {
        Assert.IsFalse(spawnPoints.Length <= 0);
        StoreBall.OnGoal += AttendGoal;
        ScoreManager.OnGameEnd += AttendEndGame;
    }


    private void SpawnBall()
    {
        int ballIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(ballClass, spawnPoints[ballIndex].transform.position, Quaternion.identity);

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
        if (isGameOver)
            return;

        Invoke("SpawnBall", waitTime);

        if (randomTrash)
        {
            Destroy(trash);
            SpawnTrash();
        }
    }

    public void AttendEndGame()
    {
        isGameOver = true;
    }

}
