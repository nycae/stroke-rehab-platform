using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCountdown : MonoBehaviour
{
    [SerializeField]
    private Text countdownText;

    [SerializeField]
    private PoseManager poseManager;

    [SerializeField]
    private Color countdownColor;

    [SerializeField]
    private Color captureColor;

    // Update is called once per frame
    void Update()
    {
        if (poseManager.IsNextGestureNuitrack())
        {
            //countdownText.text = "";
        }
        else
        {
            if (poseManager.IsCollectingData())
            {
                //countdownText.color = captureColor;
                countdownText.text = (Time.time - poseManager.GetTimestamp()).ToString("0.00");
            }
            else
            {
                //countdownText.color = countdownColor;
                countdownText.text = (Time.time - poseManager.GetTimestamp()).ToString("0.00");
            }
        }
    }
}
