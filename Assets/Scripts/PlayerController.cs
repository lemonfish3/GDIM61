using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class sc : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    public CameraController cameraController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Debug.Log("PlayerController initialized.");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY).normalized;

        // Debug.Log($"Move Input: X={moveX}, Y={moveY}");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
        // Debug.Log($"Player Position: {rb.position}");
        if (cameraController)
        {
            cameraController.CheckCameraShift(rb.position);
        }
    }
}
