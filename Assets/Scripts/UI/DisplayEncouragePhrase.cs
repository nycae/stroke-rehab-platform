using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayEncouragePhrase : MonoBehaviour
{
    [SerializeField]
    private string[] congratMsgList;

    [SerializeField]
    private Text logText;

    private int lastMessageIndex = 0;


    void Start()
    {
        StoreBall.OnGoal += DisplayNewPhrase;
    }

    void DisplayNewPhrase()
    {
        int newMessageIndex = Random.Range(0, congratMsgList.Length);
        while (newMessageIndex == lastMessageIndex)
            newMessageIndex = Random.Range(0, congratMsgList.Length);

        logText.text = congratMsgList[newMessageIndex];
    }

}
