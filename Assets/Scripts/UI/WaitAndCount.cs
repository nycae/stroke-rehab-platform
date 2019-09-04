using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitAndCount : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private PoseManager poseManager;

    [SerializeField]
    private Image img;

    [SerializeField]
    private Color countdownColor;

    [SerializeField]
    private Color captureColor;

    void Update()
    {
        if (poseManager.IsNextGestureNuitrack())
        {
            slider.value = 0.0f;
            img.color = captureColor;
        }
        else
        {
            if (poseManager.IsCollectingData())
            {
                img.color = captureColor;
                slider.value = ((float) poseManager.GetFrameIndex()) / 90f;
            }
            else
            {
                img.color = countdownColor;
                slider.value = ((poseManager.GetTimestamp() + 3f) - Time.time) / 3f;
            }
        }
    }
}
