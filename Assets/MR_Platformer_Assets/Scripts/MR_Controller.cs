using StarterAssets;
using UnityEngine;
using UnityEngine.XR;

public class MR_Controller : MonoBehaviour
{

    Vector2 moveVector;
    bool jumping;
    bool dashing;
    float sprint;
    bool rotateRight, rotateLeft;

    [SerializeField]
    StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        var leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        var rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        leftController.TryGetFeatureValue(CommonUsages.primary2DAxis, out moveVector);
        rightController.TryGetFeatureValue(CommonUsages.trigger, out sprint);
        rightController.TryGetFeatureValue(CommonUsages.primaryButton, out jumping);
        rightController.TryGetFeatureValue(CommonUsages.secondaryButton, out dashing);

        starterAssetsInputs.MoveInput(moveVector);
        starterAssetsInputs.JumpInput(jumping);
        starterAssetsInputs.dash = dashing;
        starterAssetsInputs.SprintInput(sprint != 0);
    }

}