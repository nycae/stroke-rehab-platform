using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnTouchSceneLoad : MonoBehaviour
{
    [SerializeField]
    public string levelToLoad;

    [SerializeField]
    public Text timeText;

    [SerializeField]
    public ProgressBarCircle progressBar;

    [SerializeField]
    public float timeToStartLevel = 5f;

    private float startTime;

    private float elapsedTime;

    private bool isTimerOn = false;

    private void Update()
    {
        if (isTimerOn)
        {
            elapsedTime = (Time.time - startTime);
            timeText.text = elapsedTime.ToString("0.00");
            progressBar.BarValue = elapsedTime / timeToStartLevel * 100;

            if (elapsedTime >= timeToStartLevel)
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (CurrentUserTracker.CurrentSkeleton != null)
        {
            // Start Timer
            startTime = Time.time;
            isTimerOn = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        timeText.text = "0";
        progressBar.BarValue = 0;
        isTimerOn = false;
    }
}
