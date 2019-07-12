using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateProgressBar : MonoBehaviour
{
    [SerializeField]
    public CleanGameManager gameManager;

    [SerializeField]
    public Slider slider;


    void Start()
    {
        if (slider == null)
            slider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = gameManager.GetScoreProportion();
    }
}
