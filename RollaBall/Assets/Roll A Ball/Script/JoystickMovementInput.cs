using UnityEngine;
using UnityEngine.InputSystem;

public class JoystickMovementInput : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 moveInput;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        rb.AddForce(move * speed);
    }
}
