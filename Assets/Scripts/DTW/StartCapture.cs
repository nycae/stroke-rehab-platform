using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCapture : MonoBehaviour
{
    [SerializeField]
    DTWManager dtwManager;

    private void OnTriggerEnter(Collider other)
    {
        dtwManager.OnCaptureStart();
        Destroy(gameObject);
    }
}
