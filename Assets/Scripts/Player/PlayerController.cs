using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    public Vector2 lastMoveDirection = Vector2.right;
    public Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("Start method called!");
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        float speed = moveInput.magnitude;
        animator.SetFloat("xVelocity", speed);

        if (moveInput != Vector2.zero)
        {
            lastMoveDirection = moveInput;
            animator.SetFloat("Horizontal", moveInput.x);
            animator.SetFloat("Vertical", moveInput.y);
        }
        if (moveX > 0.1f)
        {
            transform.localScale = new Vector3(2, 2, 1);
        }
        else if (moveX < -0.1f) 
        {
            transform.localScale = new Vector3(-2, 2, 1);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

}
