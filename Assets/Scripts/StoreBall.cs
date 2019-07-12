using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreBall : MonoBehaviour
{

    [SerializeField]
    public UnityEngine.UI.Text logText;

    [SerializeField]
    public ManageScore scoreManager;

    [SerializeField]
    public SpawnManagerBehaviour spawnManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            scoreManager.OnGoal();
            spawnManager.OnGoal();
            Destroy(other.gameObject);
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
