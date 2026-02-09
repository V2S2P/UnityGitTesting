using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float jumpHeight = 2.5f;
    public float gravity = -9.81f;
    public float mouseSensitivity = 100f;

    public Transform groundCheck;     // NEW
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float yVelocity;
    float yRotation;

    bool isGrounded;

    void Update()
    {
        Look();
        Move();
    }

    void Move()
    {
        // Ground Check (better than controller.isGrounded)
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && yVelocity < 0)
            yVelocity = -2f;

        // Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z) * speed;

        // Jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravity
        yVelocity += gravity * Time.deltaTime;
        move.y = yVelocity;

        controller.Move(move * Time.deltaTime);
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }
}