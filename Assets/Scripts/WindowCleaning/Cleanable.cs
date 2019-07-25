using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Size
{
    Small,
    Medium,
    Big
}

public class Cleanable : MonoBehaviour
{
    [SerializeField]
    public GameObject MediumSample;

    [SerializeField]
    public GameObject SmallSample;

    [SerializeField]
    private Size size;

    private bool isLocked = true;

    private bool isBeingUnlocked = false;

    public delegate void UserClean();

    public static event UserClean OnNewClean;

    void OnTriggerExit(Collider other)
    {
        if (isLocked)
        {
            if (!isBeingUnlocked)
            {
                Invoke("Unlock", 1f);
                isBeingUnlocked = true;
            }
        }
        else
        {
            isLocked = true;
            OnNewClean();
            switch (size)
            {
                case Size.Small:
                    Destroy(gameObject);
                    break;
                case Size.Medium:
                    Instantiate(SmallSample, gameObject.transform.position, gameObject.transform.localRotation);
                    Destroy(gameObject);
                    break;
                case Size.Big: Instantiate(MediumSample, gameObject.transform.position, gameObject.transform.localRotation);
                    Destroy(gameObject);
                    break;
            }
        }
    }

    void Unlock()
    {
        isLocked = false;
        isBeingUnlocked = false;
    }

}
