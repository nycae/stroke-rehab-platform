using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBall : MonoBehaviour
{
    [SerializeField]
    public UnityEngine.UI.Text logText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            GameObject grabbedBall = other.gameObject;

            grabbedBall.SetActive(true);
            grabbedBall.transform.tag = "Ball";
            grabbedBall.transform.parent = transform;
            grabbedBall.transform.position = transform.position;
        }
    }
}
