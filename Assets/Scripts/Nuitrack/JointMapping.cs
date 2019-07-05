using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointMapping : MonoBehaviour
{
    [Header("Rigged model")]
    [SerializeField]
    ModelJoint[] modelJoints;

    bool freeMovement = false;
    bool bodyMovement = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var modelJoint in modelJoints)
            modelJoint.baseRotOffset = modelJoint.bone.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentUserTracker.CurrentSkeleton != null)
        {
            ProcessSkeleton(CurrentUserTracker.CurrentSkeleton);
            if (freeMovement) MoveBody(CurrentUserTracker.CurrentSkeleton);
            if (bodyMovement) MoveTorso(CurrentUserTracker.CurrentSkeleton);
        }
    }

    void MoveTorso(nuitrack.Skeleton skeleton)
    {
        Vector3 torsoPos = (0.001f * skeleton.GetJoint(nuitrack.JointType.Torso).ToVector3());
        transform.position = torsoPos;
    }

    void MoveBody(nuitrack.Skeleton skeleton)
    {
        foreach (ModelJoint modelJoint in modelJoints)
            modelJoint.bone.position = (0.001f * skeleton.GetJoint(modelJoint.jointType).ToVector3());
    }

    void ProcessSkeleton(nuitrack.Skeleton skeleton)
    {
        foreach (var modelJoint in modelJoints)
            modelJoint.bone.rotation = 
                Quaternion.Inverse(CalibrationInfo.SensorOrientation) 
                * (skeleton.GetJoint(modelJoint.jointType).ToQuaternionMirrored()) 
                * modelJoint.baseRotOffset;
    }
}
