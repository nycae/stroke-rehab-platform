using UnityEngine;
using System.Collections.Generic;

public class RiggedAvatar : MonoBehaviour
{
    [Header("Rigged model")]
    [SerializeField]
    ModelJoint[] modelJoints;

    Dictionary<nuitrack.JointType, ModelJoint> jointsRigged = new Dictionary<nuitrack.JointType, ModelJoint>();

    void Start()
    {
        for (int i = 0; i < modelJoints.Length; i++)
        {
            modelJoints[i].baseRotOffset = modelJoints[i].bone.rotation;
            jointsRigged.Add(modelJoints[i].jointType, modelJoints[i]);
        }
    }

    void Update()
    {
        if (CurrentUserTracker.CurrentSkeleton != null) ProcessSkeleton(CurrentUserTracker.CurrentSkeleton);

    }

    void ProcessSkeleton(nuitrack.Skeleton skeleton)
    {
        //Vector3 torsoPos = Quaternion.Euler(0f, 0f, 0f) * (0.001f * skeleton.GetJoint(nuitrack.JointType.Torso).ToVector3());
        //transform.position = torsoPos;

        foreach (var riggedJoint in jointsRigged)
        {
            nuitrack.Joint joint = skeleton.GetJoint(riggedJoint.Key);
            ModelJoint modelJoint = riggedJoint.Value;

            Quaternion jointOrient = 
                Quaternion.Inverse(CalibrationInfo.SensorOrientation) 
                * (joint.ToQuaternionMirrored()) 
                * modelJoint.baseRotOffset;
            modelJoint.bone.rotation = jointOrient;
        }
    }
}