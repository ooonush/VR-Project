using UnityEngine;

namespace Gameplay
{
    public class InventorySlot : MonoBehaviour
    {
        public InventoryItem ItemInSlot;
        private bool _currentIsKinematic;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out InventoryItem item))
            {
                item.OnActivated += OnItemActivated;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out InventoryItem item))
            {
                item.OnActivated -= OnItemActivated;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (ItemInSlot == null && other.TryGetComponent(out InventoryItem item))
            {
                InsertItem(item);
            }
        }

        private void OnItemActivated(InventoryItem item)
        {
            if (ItemInSlot != null) return;
            
            InsertItem(item);
        }
        
        private void InsertItem(InventoryItem item)
        {
            item.OnGrabEntered += RemoveItem;

            if (item.TryGetComponent(out Rigidbody rb))
            {
                _currentIsKinematic = rb.isKinematic;
                rb.isKinematic = true;
            }
            
            ItemInSlot = item;
            item.transform.SetParent(transform);
            item.transform.position = Vector3.zero;
            item.transform.rotation = Quaternion.identity;
        }
        
        private void RemoveItem(InventoryItem item)
        {
            item.OnGrabEntered -= RemoveItem;
            
            if (item.TryGetComponent(out Rigidbody rb))
            {
                rb.isKinematic = _currentIsKinematic;
            }
            
            ItemInSlot = null;
            transform.SetParent(null);
        }
    }
}