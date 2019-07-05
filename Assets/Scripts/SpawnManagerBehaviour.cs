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

    private float lastGoalTime;

    private bool isBallSpawned;

    private void Start()
    {
        Assert.IsNotNull(spawnPoints);
        Assert.IsFalse(spawnPoints.Length <= 0);
    }

    private void Update()
    {
        if (!isBallSpawned
            &&
            (Time.time - lastGoalTime) >= waitTime)
        {
            SpawnBall();
        }
    }
    private void SpawnBall()
    {
        int ballIndex, trashIndex;

        ballIndex = Random.Range(0, spawnPoints.Length);
        do { trashIndex = Random.Range(0, spawnPoints.Length); }
        while (trashIndex == ballIndex);

        Instantiate(ballClass, spawnPoints[ballIndex].transform.position, Quaternion.identity);
        Instantiate(trashClass, spawnPoints[trashIndex].transform.position, Quaternion.identity);

        isBallSpawned = true;
    }

    public void OnGoal()
    {
        lastGoalTime = Time.time;
        isBallSpawned = false;
    }

}
