using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseScoreManager : ScoreManager
{

    public PoseScoreManager() : base()
    {
        PoseManager.OnNewGoal += AttendGoal;
    }

    public void AttendGoal()
    {
        UpdateScore(score + 1);
    }

}
