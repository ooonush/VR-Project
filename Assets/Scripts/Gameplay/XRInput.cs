using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Gameplay
{
    public class DoorInteractable : XRBaseInteractable
    {
        private Vector3 _startPosition;
        
        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);

            _startPosition = transform.position;
        }

        public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
        {
            base.ProcessInteractable(updatePhase);

            IXRSelectInteractor interactor = interactorsSelecting[0];
            Vector3 position = transform.position;
        }
    }
    
    
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
            
            XRIDefaultInputActions.XRILeftHandLocomotionActions leftHandLocomotion = _inputActions.XRILeftHandLocomotion;
            
            TeleportModeActivateAction = new XRInputAction<Vector2>(leftHandLocomotion.TeleportModeActivate);
            TeleportModeCancelAction = new XRInputAction(leftHandLocomotion.TeleportModeCancel);
            MoveAction = new XRInputAction<Vector2>(leftHandLocomotion.Move);

            TeleportModeActivateAction.OnPerformed += _ => Debug.Log("TeleportModeActivateAction");
            TeleportModeCancelAction.OnPerformed += () => Debug.Log("TeleportModeCancelAction");
            MoveAction.OnPerformed += _ => Debug.Log("MoveAction");

            RightHandControllerInput.SelectAction.Action.performed += (_) => Debug.Log("RightHandControllerInput.SelectAction");
            LeftHandControllerInput.SelectAction.Action.performed += (_) => Debug.Log("LeftHandControllerInput.SelectAction");
        }

        private void Start()
        {
            _inputActions.Enable();
        }
    }
}