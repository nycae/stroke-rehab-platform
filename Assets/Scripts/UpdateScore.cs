using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    [SerializeField]
    ManageScore scoreManager;

    [SerializeField]
    Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreManager.GetScore().ToString();
    }
}
