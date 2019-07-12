using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCapture : MonoBehaviour
{
    [SerializeField]
    DTWManager dtwManager;

    [SerializeField]
    UpdateTime timeUpdater;

    private void OnTriggerEnter(Collider other)
    {
        dtwManager.OnCaptureStart();
        timeUpdater.StartTimer();
        Destroy(gameObject);
    }
}
