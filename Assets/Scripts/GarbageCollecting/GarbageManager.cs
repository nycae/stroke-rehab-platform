using UnityEngine;

public class GarbageManager : ScoreManager
{
    override protected void Start()
    {
        base.Start();
        StoreBall.OnGoal += AttendGoal;
    }

    public void AttendGoal()
    {
        UpdateScore(score + 1);
    }

}
