using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateProgressBar : MonoBehaviour
{
    [SerializeField]
    private ScoreManager scoreManager;

    [SerializeField]
    private Text text;

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
        float proportion = (float)scoreManager.GetScore() / (float)scoreManager.GetMaxScore();

        slider.value = proportion;
        text.text = (proportion * 100f).ToString("0.00") + "%";
    }
}
