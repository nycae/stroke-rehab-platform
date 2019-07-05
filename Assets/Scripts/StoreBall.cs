using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreBall : MonoBehaviour
{

    [SerializeField]
    public UnityEngine.UI.Text logText;

    [SerializeField]
    public ManageScore scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            if (scoreManager)
                scoreManager.OnGoal();
            else
                logText.text = "Can't reach the score manager";

            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            logText.text = "Error de etiquetas, ha sido tocado por " + other.gameObject.tag;
        }
    }

    private GameObject GetBall(GameObject candidate)
    {
        for (int i = 0; i < candidate.transform.childCount; i++)
        {
            if (candidate.transform.GetChild(i).tag == "Ball")
                return candidate.transform.GetChild(i).gameObject;
        }

        return null;
    }

}
