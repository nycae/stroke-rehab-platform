using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanable : MonoBehaviour
{
    [SerializeField]
    public CleanGameManager cleanManager;

    private void OnTriggerEnter(Collider other)
    {
        cleanManager.OnNewClean();
        Destroy(this.gameObject);
    }

}
