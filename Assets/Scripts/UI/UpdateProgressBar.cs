using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateProgressBar : MonoBehaviour
{
    [SerializeField]
    private ScoreManager scoreManager;

    [SerializeField]
    private Slider slider;


    void Start()
    {
        if (slider == null)
            slider = gameObject.GetComponent<Slider>();

        if (scoreManager == null)
            scoreManager = (ScoreManager)FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        slider.value = (float)scoreManager.GetScore() / (float)scoreManager.GetMaxScore();
    }
}
