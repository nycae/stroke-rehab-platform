using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpeechManager : MonoBehaviour
{
    [SerializeField]
    public Text dialogTextLeft;

    [SerializeField]
    public Text dialogTextRight;

    [SerializeField]
    public RawImage leftImage;

    [SerializeField]
    public RawImage rightImage;

    [SerializeField]
    public GameObject button;

    [SerializeField]
    public Vector3 buttonPosition;

    [SerializeField]
    public string[] dialogs;

    private int dialogIndex = 0;


    private void Start()
    {
        Screen.SetResolution(1280, 720, true);

        leftImage.enabled = false;
        rightImage.enabled = false;

        NuitrackManager.GestureRecognizer.OnNewGesturesEvent += CloseOnWaving;
    }

    public void StartSpeech()
    {
        Invoke("NextText", 1f);
    }

    public void NextText()
    {
        if (dialogIndex >= 10) LoadMainMenu();

        if (dialogIndex % 2 == 0)
        {
            dialogTextLeft.text = dialogs[dialogIndex];
            leftImage.enabled = true;

            dialogTextRight.text = "";
            rightImage.enabled = false;
        }
        else
        {
            dialogTextRight.text = dialogs[dialogIndex];
            rightImage.enabled = true;

            dialogTextLeft.text = "";
            leftImage.enabled = false;
        }

        dialogIndex++;

        if (dialogIndex != 7)   Invoke("NextText", 10f);
        else                    MoveButton();
    }

    private void MoveButton()
    {
        button.transform.position = buttonPosition;
    }
    
    public void CloseOnWaving(nuitrack.GestureData gestures)
    {
        foreach (nuitrack.Gesture gesture in gestures.Gestures)
        {
            if (gesture.Type == nuitrack.GestureType.GestureWaving)
            {
                if (dialogIndex % 2 == 0)
                {
                    dialogTextLeft.text = "You have skipped the tutorial";
                    leftImage.enabled = true;

                    dialogTextRight.text = "";
                    rightImage.enabled = false;
                }
                else
                {
                    dialogTextRight.text = "You have skipped the tutorial";
                    rightImage.enabled = true;

                    dialogTextLeft.text = "";
                    leftImage.enabled = false;
                }

                Invoke("LoadMainMenu", 5f);
            }
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

}
