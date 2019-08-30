using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreBall : MonoBehaviour
{
    public delegate void Goal();

    public static event Goal OnGoal;

    private void OnTriggerEnter(Collider other)
    {
        OnGoal();
        Destroy(other.gameObject);
    }
/*
    private GameObject GetBall(GameObject candidate)
    {
        for (int i = 0; i < candidate.transform.childCount; i++)
        {
            if (candidate.transform.GetChild(i).tag == "Ball")
                return candidate.transform.GetChild(i).gameObject;
        }

        return null;
    }
*/
}
