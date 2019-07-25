using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CleanGameManager : ScoreManager
{
    [SerializeField]
    public Vector3 frameFinalPosition;

    [SerializeField]
    public GameObject frame;

    override protected void Start()
    {   
        base.Start();
        Cleanable.OnNewClean += OnNewClean;
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
