using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SquarePlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Gun gun;



    private Animator animator;

    private bool isMoving = false;

    public float walkDuration = 0.5f; //adjust to match walk animation length

    Vector2 moveDirection;
    Vector2 mousePosition;

    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
{
    float moveX = Input.GetAxisRaw("Horizontal");
    float moveY = Input.GetAxisRaw("Vertical");

    moveDirection = new Vector2(moveX, moveY).normalized;

    // walk animation control
    isMoving = moveDirection.sqrMagnitude > 0;
    animator.SetBool("isWalking", isMoving);

    if (Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0))
    {
        gun.Fire();
    }

    Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    gun.AimAt(mouseWorldPosition);

    // flip player
    if (moveX > 0.1f)
        transform.localScale = new Vector3(2, 2, 1);
    else if (moveX < -0.1f)
        transform.localScale = new Vector3(-2, 2, 1);
}



    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        /*Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;*/
    }
}
