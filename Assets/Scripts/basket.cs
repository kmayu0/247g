using UnityEngine;
using UnityEngine.InputSystem; // New Input System

public class basket : MonoBehaviour
{
    Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            if (tr.position.x < 5f) tr.position += new Vector3(0.2f, 0f, 0f);
        }

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            if (tr.position.x > -5f) tr.position += new Vector3(-0.2f, 0f, 0f);
        }
    }
}
