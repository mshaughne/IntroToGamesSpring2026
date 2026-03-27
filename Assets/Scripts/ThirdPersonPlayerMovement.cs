using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonPlayerMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float jumpForce = 300f;

    [SerializeField] Transform cameraPivot;
    [SerializeField] Transform groundCheckPos;
    [SerializeField] LayerMask groundLayers;
    private Rigidbody rb;

    float vertical;
    float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // cursor locks to center of screen
        Cursor.lockState = CursorLockMode.Locked;
        // make the cursor invisible
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump"))
        {
            if(Physics.Raycast(groundCheckPos.position, Vector3.down, 0.1f, groundLayers))
            {
                rb.AddForce(0, jumpForce, 0);
            }
        }

        if(Input.GetButtonDown("Cancel"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }

    private void FixedUpdate()
    {
        Vector3 input = new Vector3(horizontal, 0, vertical);
        Vector3 camForward = cameraPivot.forward;
        Vector3 camRight = cameraPivot.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        if (input.magnitude > 0.1f)
        {
            Vector3 moveDir = camForward * vertical + camRight * horizontal;

            rb.velocity = new Vector3(moveDir.x * moveSpeed, rb.velocity.y, moveDir.z * moveSpeed);

            //Quaternion targetRot = Quaternion.LookRotation(moveDir);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }
}
