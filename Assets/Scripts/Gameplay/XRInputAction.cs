using System;
using UnityEngine.InputSystem;

namespace Gameplay
{
    public class XRInputAction
    {
        public readonly InputAction Action;
        public event Action OnPerformed;
        public event Action OnCanceled;
        public event Action OnStarted;
        
        public XRInputAction(InputAction inputAction)
        {
            Action = inputAction;
            inputAction.started += Started;
            inputAction.performed += Performed;
            inputAction.canceled += Canceled;
        }

        private void Started(InputAction.CallbackContext callbackContext)
        {
            OnStarted?.Invoke();
        }

        private void Performed(InputAction.CallbackContext callbackContext)
        {
            OnPerformed?.Invoke();
        }

        private void Canceled(InputAction.CallbackContext callbackContext)
        {
            OnCanceled?.Invoke();
        }
    }
    
    public class XRInputAction<T> where T : struct
    {
        public readonly InputAction Action;
        public event Action<T> OnPerformed;
        public event Action<T> OnCanceled;
        public event Action<T> OnStarted;

        public XRInputAction(InputAction inputAction)
        {
            Action = inputAction;
            inputAction.started += Started;
            inputAction.performed += Performed;
            inputAction.canceled += Canceled;
        }

        private void Started(InputAction.CallbackContext callbackContext)
        {
            OnStarted?.Invoke(callbackContext.ReadValue<T>());
        }

        private void Performed(InputAction.CallbackContext callbackContext)
        {
            OnPerformed?.Invoke(callbackContext.ReadValue<T>());
        }

        private void Canceled(InputAction.CallbackContext callbackContext)
        {
            OnCanceled?.Invoke(callbackContext.ReadValue<T>());
        }
    }
}