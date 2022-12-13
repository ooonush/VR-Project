using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Gameplay.GameplayObjects
{
    public class HandAnimator : MonoBehaviour
    {
        public Animator Animator;
        public ActionBasedController ActionBasedController;
        private static readonly int Activate = Animator.StringToHash("Activate");
        private static readonly int Select = Animator.StringToHash("Select");
    
        private void Update()
        {
            // Animator.SetFloat(Activate, ActionBasedController.activateAction.action.ReadValue<float>());
            // Animator.SetFloat(Select, ActionBasedController.selectAction.action.ReadValue<float>());
        }
    }
}
