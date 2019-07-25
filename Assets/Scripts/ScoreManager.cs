using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    protected int score = 0;

    [SerializeField]
    protected int targetScore;

    [SerializeField]
    protected int delayTime = 2;

    public delegate void GameFinished();

    public static event GameFinished OnGameEnd;

    protected virtual void Start()
    {
        OnGameEnd += EndGameOperations;
    }

    private void EndGameOperations()
    {
        Invoke("LoadMainMenu", delayTime);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    protected void UpdateScore(int newScore)
    {
        score = newScore;
        if (score >= targetScore) OnGameEnd();
    }

    public int GetScore()
    {
        return score;
    }

    public int GetMaxScore()
    {
        return targetScore;
    }
}
