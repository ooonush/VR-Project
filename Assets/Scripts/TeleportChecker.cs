using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportChecker : MonoBehaviour
{
    [SerializeField] private XRRayInteractor _rayInteractor;
    [SerializeField] private TeleportationProvider _teleportationProvider;
    private InputAction _leftHandMoveStick;
    private bool _activated;

    private XRIDefaultInputActions _inputActions;
    
    private void Start()
    {
        _inputActions = new XRIDefaultInputActions();
        _inputActions.Enable();
        _rayInteractor.enabled = false;
        
        _inputActions.XRILeftHandLocomotion.TeleportModeActivate.performed += OnTeleportActivate;
        _inputActions.XRILeftHandLocomotion.TeleportModeCancel.performed += OnTeleportCancel;
        _leftHandMoveStick = _inputActions.XRILeftHandLocomotion.Move;
    }
    
    private void Update()
    {
        if (!_activated || _leftHandMoveStick.triggered)
        {
            return;
        }

        if (!_rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            DisableRayInteractor();
            return;
        }

        var request = new TeleportRequest
        {
            destinationPosition = hit.point,
        };
        _teleportationProvider.QueueTeleportRequest(request);
    }
    
    private void OnTeleportActivate(InputAction.CallbackContext context)
    {
        EnableRayInteractor();
    }

    private void OnTeleportCancel(InputAction.CallbackContext context)
    {
        DisableRayInteractor();
    }

    private void EnableRayInteractor()
    {
        _rayInteractor.enabled = true;
        _activated = true;
    }

    private void DisableRayInteractor()
    {
        _rayInteractor.enabled = false;
        _activated = false;
    }
}
