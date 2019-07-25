using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnTouchSceneLoad : MonoBehaviour
{
    [SerializeField]
    public string levelToLoad;

    [SerializeField]
    public Text textBox;

    [SerializeField]
    public Text timeText;

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

            if (elapsedTime >= timeToStartLevel)
            {
                textBox.text = "Loading level: " + levelToLoad;
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var outline = textBox.GetComponent<UnityEngine.UI.Outline>();

        if (outline != null)
            outline.effectColor = new Color(50f, 255f, 50f);

        textBox.color = new Color(0f, 255f, 0f);
        textBox.text = name + " has been touched";

        if (CurrentUserTracker.CurrentSkeleton != null)
        {
            // Start Timer
            startTime = Time.time;
            isTimerOn = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        // End timer
        textBox.text = "";
        timeText.text = "0";
        isTimerOn = false;
    }
}
