using UnityEngine;

[System.Serializable]
class ModelJoint
{
    public Transform bone = null;
    public nuitrack.JointType jointType = nuitrack.JointType.None;
    public nuitrack.JointType parentJointType = nuitrack.JointType.None;

    [HideInInspector] public Quaternion baseRotOffset;
    [HideInInspector] public Transform parentBone;
    [HideInInspector] public float baseDistanceToParent;
}
