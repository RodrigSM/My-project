using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody PlayerRigidbody { get => playerRigidbody; }
    private Rigidbody playerRigidbody;

    private float speed = 1000f;
    private Vector3 movement;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputMovement();
    }

    private void FixedUpdate()
    {
        PhysicsMovement();
    }

    private void InputMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = (transform.right * moveHorizontal) + (transform.forward * moveVertical);
    }

    private void PhysicsMovement()
    {
        playerRigidbody.AddForce(movement.normalized * speed * Time.fixedDeltaTime);
    }
}
