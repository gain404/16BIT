using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public bool isDie = false;
    protected bool isGrounded = false;

    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D _rigidbody;
    protected Animator animator;

    public PlayerType playerType;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    //get the input keys from InputManager
    protected abstract string GetHorizontalAxis();
    protected abstract string GetJumpButton();
    protected virtual void Update()
    {
        float horizontal = Input.GetAxisRaw(GetHorizontalAxis());

        Move(horizontal);

        if (isGrounded && Input.GetButtonDown(GetJumpButton()))
        {
            Jump();
        }

        //flip sprites based on the input keys
        if (Input.GetAxisRaw(GetHorizontalAxis()) > 0)
        {
            this.spriteRenderer.flipX = false;  // flip to right
        }
        else if (Input.GetAxisRaw(GetHorizontalAxis()) < 0)
        {
            this.spriteRenderer.flipX = true;   // flip to left
        }

        bool isMoving = Mathf.Abs(horizontal) > 0.1f;
        float speed = _rigidbody.velocity.magnitude;

        animator.SetFloat("run", speed);
        animator.SetBool("isJumping", !isGrounded);
        //animator.SetBool("isRunning", isMoving);
    }

    public virtual void Move(float horizontal)
    {
        _rigidbody.velocity = new Vector2(horizontal * moveSpeed, _rigidbody.velocity.y);
    }

    public virtual void Jump()
    {
        _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); 
    }

    //checking jumpable conditions
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}