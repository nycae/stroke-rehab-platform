using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoseScoreManager : MonoBehaviour
{
    [SerializeField]
    private int targetScore;

    [SerializeField]
    private float waitTime;

    private int score = 0;

    public void OnNewGoal()
    {
        score++;
        if (score >= targetScore)
        {
            Invoke("LoadMainMenu", waitTime);
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public int GetScore()
    {
        return score;
    }
}
