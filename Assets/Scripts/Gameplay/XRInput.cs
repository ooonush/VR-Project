using UnityEngine;

namespace Gameplay
{
    public class XRInput : MonoBehaviour
    {
        public XRControllerInput RightHandControllerInput;
        public XRControllerInput LeftHandControllerInput;
        
        public XRInputAction<Vector2> TeleportModeActivateAction;
        public XRInputAction TeleportModeCancelAction;
        public XRInputAction<Vector2> MoveAction;
        
        private XRIDefaultInputActions _inputActions;
        
        private void Awake()
        {
            _inputActions = new XRIDefaultInputActions();
            _inputActions.Enable();

            XRIDefaultInputActions.XRILeftHandLocomotionActions leftHandLocomotion = _inputActions.XRILeftHandLocomotion;
            
            TeleportModeActivateAction = new XRInputAction<Vector2>(leftHandLocomotion.TeleportModeActivate);
            TeleportModeCancelAction = new XRInputAction(leftHandLocomotion.TeleportModeCancel);
            MoveAction = new XRInputAction<Vector2>(leftHandLocomotion.Move);
        }
    }
}