using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLanguaje : MonoBehaviour
{
    [SerializeField]
    public GameObject flagParent;

    [SerializeField]
    public GameObject otherLanguaje;

    [SerializeField]
    public SpeechManager speechManager;

    [TextArea]
    public string[] dialogs;

    private void OnTriggerEnter(Collider other)
    {
        speechManager.dialogs = this.dialogs;

        Destroy(flagParent);
        Destroy(otherLanguaje);
        Destroy(gameObject);

        speechManager.StartSpeech();
    }
}
