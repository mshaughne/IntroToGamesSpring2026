using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    Vector3 playerInput;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 300f;

    [Header("Ground Detection")]
    [SerializeField] LayerMask groundLayers;
    [SerializeField] float checkRadius = 1f;
    [SerializeField] Transform groundCheckPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
        
        if(Input.GetButtonDown("Jump") && Physics.CheckSphere(groundCheckPos.position, checkRadius, groundLayers))
        {
            rb.AddForce(0, jumpForce, 0);
        }
    }

    private void FixedUpdate()
    {
        //rb.AddForce(Vector3.left * 5f);

        //rb.AddForce(playerInput * moveSpeed);
    }


















    /*[SerializeField] Rigidbody rb;
    Vector3 playerInput;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(Vector3.left * 5f * Time.deltaTime);

        playerInput = new Vector3(Input.GetAxis("Horizontal"),
            0, Input.GetAxis("Vertical"));

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(0, jumpForce, 0);
        }
    }

    private void FixedUpdate()
    {
        //rb.AddForce(Vector3.left * 5f);

        rb.AddForce(playerInput * moveSpeed);
    }*/
}
