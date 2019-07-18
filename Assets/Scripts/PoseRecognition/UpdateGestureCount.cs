using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateGestureCount : MonoBehaviour
{
    [SerializeField]
    private PoseScoreManager scoreManager;

    [SerializeField]
    private Text scoreText;

    private void Update()
    {
        scoreText.text = scoreManager.GetScore().ToString();
    }
}
