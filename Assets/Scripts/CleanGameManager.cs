using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CleanGameManager : MonoBehaviour
{
    [SerializeField]
    public int targetCleans;

    [SerializeField]
    public float timeToLoadNextLevel = 3.0f;

    [SerializeField]
    public Text logText;

    [SerializeField]
    public Vector3 frameFinalPosition;

    [SerializeField]
    public GameObject frame;

    private int numberOfCleans = 0;


    public void OnNewClean()
    {
        numberOfCleans++;

        if (numberOfCleans >= targetCleans)
            OnGameOver();
    }

    public void Start()
    {
        targetCleans = GameObject.FindGameObjectsWithTag("Dirt").Length;
    }

    private void OnGameOver()
    {
        logText.text = "Congratulations, you cleaned the window";
        Invoke("LoadMainMenu", timeToLoadNextLevel);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void OnGrabbedCleaner()
    {
        frame.transform.position = frameFinalPosition;
    }

    public float GetScoreProportion()
        { return (float)numberOfCleans / (float)targetCleans; }
}
