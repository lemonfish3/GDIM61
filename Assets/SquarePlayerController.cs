using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SquarePlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Gun gun;

    Vector2 moveDirection;
    Vector2 mousePosition;

    // Update is called once per frame
void Update()
{
    float moveX = Input.GetAxisRaw("Horizontal");
    float moveY = Input.GetAxisRaw("Vertical");

    if (Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0))
    {
        gun.Fire();
    }

    moveDirection = new Vector2(moveX, moveY).normalized;
    Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    gun.AimAt(mouseWorldPosition);

    // Flip player based on movement direction
    if (moveX > 0.1f)
        transform.localScale = new Vector3(2, 2, 1); // face right
    else if (moveX < 0.1f)
        transform.localScale = new Vector3(-2, 2, 1); // face left
}


    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        /*Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;*/
    }
}
