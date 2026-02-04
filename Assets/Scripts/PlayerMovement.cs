using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float jumpHeight = 2.5f;
    public float gravity = -9.81f;
    public float mouseSensitivity = 100f;

    float yVelocity;
    float yRotation;

    void Update()
    {
        Look();
        Move();
    }

    void Move()
    {
        // Movement (WASD)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        // Ground check
        if (controller.isGrounded && yVelocity < 0)
        {
            yVelocity = -20f; // keeps player grounded
        }

        // Jump
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        yVelocity += gravity * Time.deltaTime;
        controller.Move(new Vector3(0, yVelocity, 0) * Time.deltaTime);
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }
}