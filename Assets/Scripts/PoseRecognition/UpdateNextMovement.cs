using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateNextMovement : MonoBehaviour
{
    [SerializeField]
    private PoseManager poseManager;

    [SerializeField]
    private Text poseText;

    // Update is called once per frame
    void Update()
    {
        poseText.text = (poseManager.IsNextGestureNuitrack()) 
            ? poseManager.GetNuitrackGestureStr() 
            : poseManager.GetCustomGestureStr();
    }
}
