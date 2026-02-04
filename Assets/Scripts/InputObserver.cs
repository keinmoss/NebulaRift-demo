using UnityEngine;
using UnityEngine.InputSystem;

public class InputObserver : MonoBehaviour
{
    public UIManager uiManager;
    public AudioManager audioManager;

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            uiManager.IncreaseSpeed();
            audioManager.PlayStep();
        }
    }
}