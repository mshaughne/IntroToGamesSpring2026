using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonPlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float rotSpeed = 12f;

    [SerializeField] Transform cameraPivot;
    private Rigidbody rb;

    float vertical;
    float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
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
