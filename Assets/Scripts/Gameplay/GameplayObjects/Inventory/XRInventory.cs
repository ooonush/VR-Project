using UnityEngine;

namespace Gameplay.GameplayObjects.Inventory
{
    public class XRInventory : MonoBehaviour
    {
        public GameObject Anchor;
        public XRInput Input;

        private void Start()
        {
            gameObject.SetActive(false);
            
            Input.LeftHandControllerInput.SelectAction.OnPerformed += ToggleVisible;
        }

        private void ToggleVisible()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        private void Update()
        {
            gameObject.transform.position = Anchor.transform.position;
            gameObject.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        }
    }
}