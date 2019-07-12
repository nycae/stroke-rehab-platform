using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBall : MonoBehaviour
{
    [SerializeField]
    public Vector3 offset;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball"
            &&
            other.gameObject.transform.parent == null)
        {
            GameObject grabbedBall = other.gameObject;

            grabbedBall.SetActive(true);
            grabbedBall.transform.tag = "Ball";
            grabbedBall.transform.parent = transform;
            grabbedBall.transform.position = transform.position;
            grabbedBall.transform.localPosition = offset;
        }
    }
}
