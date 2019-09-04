using UnityEngine;

public class GarbageManager : ScoreManager
{
    public GarbageManager() : base()
    {
        StoreBall.OnGoal += AttendGoal;
    }

    public void AttendGoal()
    {
        UpdateScore(score + 1);
    }

}
