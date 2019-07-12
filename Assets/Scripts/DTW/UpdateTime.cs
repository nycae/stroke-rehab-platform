using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTime : MonoBehaviour
{
    [SerializeField]
    Text timerText;

    [SerializeField]
    DTWManager dtwManager;

    private bool isTimerOn;

    private void Update()
    {
        if (isTimerOn)
            timerText.text = (Time.time - dtwManager.GetTimestamp()).ToString("0.00");
    }

    public void StartTimer()
    {
        isTimerOn = true;
        Invoke("StopTimer", DTWManager.numberOfSeconds);
    }

    public void StopTimer()
    {
        isTimerOn = false;
        timerText.text = "";
    }
}
