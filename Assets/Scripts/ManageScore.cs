using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageScore : MonoBehaviour
{
    private int score = 0;

    private int lastMessageIndex = 0;

    [SerializeField]
    public int targetScore = 10;

    [SerializeField]
    public int delayTime = 2;

    [SerializeField]
    public Text logText;

    [SerializeField]
    public SpawnManagerBehaviour spawnManager;

    [SerializeField]
    public string[] congratMsgList;


    public void OnGoal()
    {
        score++;

        if (score >= targetScore)
        {
            spawnManager.OnEndGame();
            OnGameEnd();
        }
        else
        {
            int newMessageIndex = Random.Range(0, congratMsgList.Length);
            while (newMessageIndex == lastMessageIndex)
                newMessageIndex = Random.Range(0, congratMsgList.Length);

            logText.text = congratMsgList[newMessageIndex];
        }
    }

    private void OnGameEnd()
    {
        Invoke("LoadMainMenu", delayTime);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public int GetScore()
        { return score; }
}
