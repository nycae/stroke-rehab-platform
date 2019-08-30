using UnityEngine;

public class GarbageManager : ScoreManager
{
    override protected void Start()
    {
        base.Start();
        StoreBall.OnGoal += AttendGoal;
        Screen.SetResolution(1280, 720, true);
    }

    public void AttendGoal()
    {
        UpdateScore(score + 1);
    }

}
