using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanGameManager : ScoreManager
{
    [SerializeField]
    public Vector3 frameFinalPosition;

    [SerializeField]
    public GameObject frame;

    public CleanGameManager() : base()
    {
        Cleanable.OnNewClean += OnNewClean;
    }

    protected void Start()
    {   
        targetScore = 3 * ((GameObject.FindGameObjectsWithTag("Dirt").Length) - 3);
    }


    public void OnNewClean()
    {
        UpdateScore(score + 1);
    }

    public void OnGrabbedCleaner()
    {
        frame.transform.position = frameFinalPosition;
    }
}
