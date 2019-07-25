using UnityEngine;

public class HandMapping : MonoBehaviour
{
    public enum Hands { left = 0, right = 1 };

    [SerializeField]
    Hands currentHand;

    [SerializeField]
    private Vector3 originalPosition;

    private void Update()
    {
        if (CurrentUserTracker.CurrentSkeleton != null)
        {
            Vector3 handPosition = (currentHand == Hands.left)
                ? CurrentUserTracker.CurrentSkeleton.GetJoint(nuitrack.JointType.LeftHand).ToVector3()
                : CurrentUserTracker.CurrentSkeleton.GetJoint(nuitrack.JointType.RightHand).ToVector3();

            //gameObject.transform.position = new Vector3(handPosition.X * Screen.width, handPosition.Y * Screen.height, 0) + originalPosition;
            handPosition *= 0.0025f;
            handPosition += originalPosition;
            handPosition.z = originalPosition.z;
            gameObject.transform.position = handPosition;
        }
    }

}

