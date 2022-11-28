using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Gameplay.Teleportation
{
    public class TeleportationTargetVisual : MonoBehaviour
    {
        public XRRayInteractor RayInteractor;
        public GameObject Visual;
        
        private void Update()
        {
            if (RayInteractor.enabled && RayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit raycastHit))
            {
                Visual.SetActive(true);
                Visual.transform.position = raycastHit.point;
            }
            
            Visual.SetActive(false);
        }
    }
}