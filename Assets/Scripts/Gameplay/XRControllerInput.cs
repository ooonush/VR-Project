using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Gameplay
{
    public class XRControllerInput : MonoBehaviour
    {
        [SerializeField] private ActionBasedController _controller;
        public XRInputAction ActivateAction { get; private set; }
        public XRInputAction<float> ActivateActionValue { get; private set; }
        public XRInputAction SelectAction { get; private set; }
        public XRInputAction<float> SelectActionValue { get; private set; }
        
        private void Awake()
        {
            ActivateAction = new XRInputAction(_controller.activateAction.action);
            ActivateActionValue = new XRInputAction<float>(_controller.activateActionValue.action);
            SelectAction = new XRInputAction(_controller.selectAction.action);
            SelectActionValue = new XRInputAction<float>(_controller.selectActionValue.action);
        }
    }
}