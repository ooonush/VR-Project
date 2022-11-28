using Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class TeleportChecker : MonoBehaviour
{
    [SerializeField] private XRRayInteractor _rayInteractor;
    [SerializeField] private TeleportationProvider _teleportationProvider;
    private InputAction _leftHandMoveStick;
    private bool _activated;

    public ActionBasedController Controller;
    
    [SerializeField] private XRInput _input;
    [SerializeField] private InputActionManager _inputActionManager;
    
    private void Start()
    {
        _rayInteractor.enabled = false;
        
        _input.TeleportModeActivateAction.OnPerformed += OnTeleportActivate;
        _input.TeleportModeCancelAction.OnPerformed += OnTeleportCancel;
        
        _leftHandMoveStick = _input.MoveAction.Action;
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
    
    private void OnTeleportActivate(Vector2 vector2)
    {
        EnableRayInteractor();
    }

    private void OnTeleportCancel()
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
