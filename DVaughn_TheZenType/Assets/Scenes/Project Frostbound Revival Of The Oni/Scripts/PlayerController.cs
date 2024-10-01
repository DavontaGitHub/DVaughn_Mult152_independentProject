using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public float verticalRotationLimit = 80.0f;
    public float gravity = -200.0f;
    public float jumpForce = 100.0f;

    private GameManager gameManager;
    private CharacterController controller;
    private float rotationX = 0;
    private Vector3 velocity;

    void Start()
    {
        // Find the Game Manager in the scene
        GameObject gameManagerObject = GameObject.Find("Game Manager");
        if (gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }

        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Handle mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the player left/right
        transform.Rotate(0, mouseX, 0);

        // Handle vertical rotation with clamping
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -verticalRotationLimit, verticalRotationLimit);

        // Rotate the camera up/down
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        // Movement
        float moveDirectionX = Input.GetAxis("Horizontal");
        float moveDirectionZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveDirectionX, 0, moveDirectionZ);
        move = transform.TransformDirection(move);

        velocity.x = move.x * speed;
        velocity.z = move.z * speed;

        // Apply gravity
        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump")) // Optional: Add jumping
            {
                velocity.y = jumpForce;
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // Move the character controller
        controller.Move(velocity * Time.deltaTime);
    }

    private void Die()
    {
       

        // Handle player death (e.g., disable player controls)
        gameObject.SetActive(false); // Disable the player object
        Invoke("Respawn", 2f); // Delay before respawning
    }
}
