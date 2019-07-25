using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoseScoreManager : ScoreManager
{
    delegate void Something();

    protected override void Start()
    {
        base.Start();
        PoseManager.OnNewGoal += AttendGoal;
    }

    public void AttendGoal()
    {
        UpdateScore(score + 1);
    }

}
