using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialog : MonoBehaviour
{
    [SerializeField]
    public SpeechManager speechManager;

    private bool isTimerPressed = false;

    private float timestamp;

    public void OnTriggerEnter(Collider other)
    {
        isTimerPressed = true;
        timestamp = Time.time;
    }

    public void OnTriggerExit(Collider other)
    {
        isTimerPressed = false;
    }

    private void Update()
    {
        if (isTimerPressed && (Time.time - timestamp) >= 5f)
        {
            speechManager.NextText();
            Destroy(this.gameObject);
        }
    }

}
