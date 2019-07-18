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

    private void Update()
    {
        if (dtwManager.IsCollectingData())
        {
            timerText.color = Color.green;
            timerText.text = (Time.time - dtwManager.GetTimestamp()).ToString("0.00");
        }
        else if (dtwManager.IsInCountdown())
        {
            timerText.color = Color.red;
            timerText.text = (Time.time - dtwManager.GetTimestamp()).ToString("0.00");
        }
        else
        {
            timerText.color = Color.green;
            timerText.text = "0.00";
        }
    }
}
