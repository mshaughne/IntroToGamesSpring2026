using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] Rigidbody rb;
    // Vector3 playerInput;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 300f;
    float horizontal;
    float vertical;

    [Header("Ground Detection")]
    [SerializeField] LayerMask groundLayers;
    [SerializeField] float checkRadius = 1f;
    [SerializeField] Transform groundCheckPos;

    [Header("Camera")]
    [SerializeField] Transform cameraPivot;
    [SerializeField] Transform cameraTransform;
    float xRotation;
    [SerializeField] float mouseSensitivity = 200f;

    private void Start()
    {
        // Get the rigidbody on game start / object start
        rb = GetComponent<Rigidbody>();

        // Lock the cursor to the game
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        Look();
        ReadInputs();

        if(Input.GetButtonDown("Jump") && Physics.CheckSphere(groundCheckPos.position, checkRadius, groundLayers))
        {
            rb.AddForce(0, jumpForce, 0);
        }
    }

    private void FixedUpdate()
    {
        Move();

        //rb.AddForce(Vector3.left * 5f);
        //rb.AddForce(playerInput * moveSpeed);
    }

    private void Move()
    {
        // Get the camera directions
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // zero out the y rotation
        forward.y = 0;
        right.y = 0;

        // set magnitude of both vectors back to 1
        forward = forward.normalized;
        right = right.normalized;

        // movement directions based on the camera rotation
        Vector3 moveDirection = forward * vertical + right * horizontal;
        // apply movement speed
        Vector3 newVelocity = moveDirection * moveSpeed;
        // set velocity to new movement direction
        rb.velocity = new Vector3(newVelocity.x, rb.velocity.y, newVelocity.z);
    }

    void ReadInputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void Look()
    {
        // get mouse rotation (framerate independent)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // vertical camera rotation
        xRotation -= mouseY; // xRotation = xRotation - mouseY
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
