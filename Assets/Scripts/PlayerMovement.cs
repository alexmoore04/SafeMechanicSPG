using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    [SerializeField] private Transform orientation;

    [SerializeField] private GameObject ui; // Codelock UI. could be made into an array to hold other types of UI

    float horizontalInput;
    float verticalInput;

    Vector3 movementDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        //prevents player from moving if the codelock UI is active
        if (ui.activeSelf == false)
        {
            MyInput();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // calculate movement direction
        movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(movementDirection.normalized * moveSpeed * 10, ForceMode.Force);
    }
}
