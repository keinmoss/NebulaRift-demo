using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 120f;
    public float jumpForce = 2f;

    private Vector2 moveInput;
    private Vector2 lookInput;

    void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.Self);

        transform.Rotate(Vector3.up * lookInput.x * rotationSpeed * Time.deltaTime);
    }


    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
            transform.position += Vector3.up * jumpForce;
    }
}

