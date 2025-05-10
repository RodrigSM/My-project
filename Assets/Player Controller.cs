using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xRotation = 0f;
    private float yRotation = 0f;
    private Rigidbody rb;

    public bool grounded;
    public bool canMove = true;
    public bool canLook = true;
    public float walkSpeed = 5f;
    public float sensitivity = 2f;
    public float jumpForce = 3.5f; // força mais realista

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ResetState();
    }

    void Update()
    {
        //HandleMouseLook();
        if (canLook)
            HandleMouseLook();
        CheckGrounded();

        if (canMove && Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    

    void FixedUpdate()
    {
        //HandleMovement();
        if (canMove)
            HandleMovement();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = (transform.right * moveX + transform.forward * moveZ).normalized;
        Vector3 velocity = moveDirection * walkSpeed;
        velocity.y = rb.linearVelocity.y;
        rb.linearVelocity = velocity;
    }

    void CheckGrounded()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    public void ResetState()
    {
        canMove = true;
        canLook = true;

        if (rb != null)
        {
            rb.isKinematic = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        Debug.Log("Player state reset.");
    }
}
