using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Gameplay
{
    [RequireComponent(typeof(Collider))]
    public class InventoryItem : MonoBehaviour
    {
        public XRGrabInteractable GrabInteractable;
        public event Action<InventoryItem> OnGrabEntered;
        public event Action<InventoryItem> OnActivated;

        private void Start()
        {
            GrabInteractable.activated.AddListener(Activated);
            GrabInteractable.selectEntered.AddListener(GrabEntered);
        }

        private void GrabEntered(SelectEnterEventArgs eventArgs)
        {
            OnGrabEntered?.Invoke(this);
        }

        private void Activated(ActivateEventArgs eventArgs)
        {
            OnActivated?.Invoke(this);
        }
    }
}