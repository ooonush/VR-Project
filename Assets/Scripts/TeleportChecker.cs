using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportChecker : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAssets;
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider provider;
    private InputAction stick;
    private bool activated;

    // Start is called before the first frame update
    void Start()
    {
        rayInteractor.enabled = false;

        var activate = actionAssets.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Activate");
        activate.Enable();
        activate.performed += OnTeleportActivate;

        var cancel = actionAssets.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Cancel");
        cancel.Enable();
        cancel.performed += OnTeleportcancel;

        stick = actionAssets.FindActionMap("XRI LeftHand Locomotion").FindAction("Move");
        stick.Enable();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (!activated)
        {
            return;
        }

        if (stick.triggered)
        {
            return;
        }

        if (!rayInteractor.GetCurrentRaycastHit(out RaycastHit hit))
        {
            rayInteractor.enabled = false;
            activated = false;
            return;
        }

        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = hit.point,
        };
        provider.QueueTeleportRequest(request);
    }

    private void OnTeleportActivate(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = true;
        activated = true;
    }
    private void OnTeleportcancel(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = false;
        activated = false;
    }
}
