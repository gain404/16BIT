using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public bool isDie = false;

    protected Rigidbody2D _rigidbody;
    protected bool isGrounded = false;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    //InputManager에서 키 설정 후 가져옴
    protected abstract string GetHorizontalAxis();
    protected abstract string GetJumpButton();
    protected virtual void Update()
    {
        //키 할당
        float horizontal = Input.GetAxisRaw(GetHorizontalAxis());

        Move(horizontal);

        if (isGrounded && Input.GetButtonDown(GetJumpButton()))
        {
            Jump();
        }
    }

    public virtual void Move(float horizontal)
    {
        _rigidbody.velocity = new Vector2(horizontal * moveSpeed, _rigidbody.velocity.y);
    }

    public virtual void Jump()
    {
        _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); 
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 땅과 충돌했을 때, isGrounded를 true로 설정
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // 땅과 떨어졌을 때, isGrounded를 false로 설정
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}