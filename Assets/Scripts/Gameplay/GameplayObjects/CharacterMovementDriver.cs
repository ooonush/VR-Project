using UnityEngine.XR.Interaction.Toolkit;

namespace Gameplay.GameplayObjects
{
    public class CharacterMovementDriver : CharacterControllerDriver
    {
        private void Update()
        {
            UpdateCharacterController();
        }
    }
}