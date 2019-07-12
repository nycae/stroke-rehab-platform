using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechManager : MonoBehaviour
{
    [SerializeField]
    public Text dialogText;

    [SerializeField]
    public GameObject button;

    [SerializeField]
    public Vector3 buttonPosition;

    [SerializeField]
    public string[] dialogs;

    private int dialogIndex = 0;


    public void StartSpeech()
    {
        Invoke("NextText", 1f);
    }

    public void NextText()
    {
        dialogText.text = dialogs[dialogIndex];

        dialogIndex++;

        if (dialogIndex != 3)   Invoke("NextText", 10f);
        else                    MoveButton();
    }

    private void MoveButton()
    {
        button.transform.position = buttonPosition;
    }
    
}
