using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckActiveState : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.name == "ActivatePoint")
        {
            Debug.Log("Рычаг активирован");
        }
        if (other.name == "DisablePoint")
        {
            Debug.Log("Рычаг дизактивирован");
        }
    }
}
