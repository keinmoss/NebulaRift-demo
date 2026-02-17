using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove_Eval1 : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, 0f, z).normalized;
        Vector3 targetPos = rb.position + dir * speed * Time.fixedDeltaTime;

        rb.MovePosition(targetPos);
    }
}