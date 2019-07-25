using UnityEngine;

public class JointMapping : MonoBehaviour
{
    [Header("Rigged model")]
    [SerializeField]
    ModelJoint[] modelJoints;

    private bool freeMovement = false;
    private bool bodyMovement = false;

    protected void Start()
    {
        foreach (var modelJoint in modelJoints)
            modelJoint.baseRotOffset = modelJoint.bone.rotation;
    }

    protected void Update()
    {
        if (CurrentUserTracker.CurrentSkeleton != null)
        {
            MoveJoints(CurrentUserTracker.CurrentSkeleton);
            if (freeMovement) MoveBody(CurrentUserTracker.CurrentSkeleton);
            if (bodyMovement) MoveTorso(CurrentUserTracker.CurrentSkeleton);
        }
    }

    private void MoveTorso(nuitrack.Skeleton skeleton)
    {
        Vector3 torsoPos = (0.001f * skeleton.GetJoint(nuitrack.JointType.Torso).ToVector3());
        transform.position = torsoPos;
    }

    private void MoveBody(nuitrack.Skeleton skeleton)
    {
        foreach (ModelJoint modelJoint in modelJoints)
            modelJoint.bone.position = (0.001f * skeleton.GetJoint(modelJoint.jointType).ToVector3());
    }

    private void MoveJoints(nuitrack.Skeleton skeleton)
    {
        foreach (var modelJoint in modelJoints)
            modelJoint.bone.rotation = 
                Quaternion.Inverse(CalibrationInfo.SensorOrientation) 
                * (skeleton.GetJoint(modelJoint.jointType).ToQuaternionMirrored()) 
                * modelJoint.baseRotOffset;
    }

    public Quaternion[] GetRotations()
    {
        Quaternion[] toReturn = new Quaternion[modelJoints.Length];

        for (int i = 0; i < modelJoints.Length; i++)
        {
            toReturn[i] = modelJoints[i].bone.rotation; //CurrentUserTracker.CurrentSkeleton.GetJoint(modelJoints[i].jointType).ToQuaternion();
        }

        return toReturn;
    }
}
