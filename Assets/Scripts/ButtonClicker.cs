using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonClicker : MonoBehaviour
{
    [SerializeField] private float treshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;
    private bool isPressed;
    private Vector3 startPosition;
    private ConfigurableJoint joint;
    private float GetValue()
    {
        var value = Vector3.Distance(startPosition, transform.localPosition) / joint.linearLimit.limit;
        if (Mathf.Abs(value) < deadZone)
        {
            value = 0;
        }
        return Mathf.Clamp(value, -1f, 1f);
    }
    public UnityEvent onPressed, OnReleased;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPressed && GetValue() + treshold >= 1)
        {
            Pressed();
        }
        if (!isPressed && GetValue() - treshold <= 0)
        {
            Released();
        }
    }

    private void Pressed()
    {
        isPressed = true;
        onPressed.Invoke();
        Debug.Log("Кнопка нажата");
    }

    private void Released()
    {
        isPressed = false;
        OnReleased.Invoke();
        Debug.Log("Кнопка отпущена");
    }
}
