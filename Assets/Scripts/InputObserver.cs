using UnityEngine;
using UnityEngine.InputSystem;

public class InputObserver : MonoBehaviour
{
    private int speed = 0;
    private int sprint = 0;

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            speed++;

            if (speed % 5 == 0)
                sprint++;

            Debug.Log($"Speed: {speed} | Sprint: {sprint}");
        }
    }
}