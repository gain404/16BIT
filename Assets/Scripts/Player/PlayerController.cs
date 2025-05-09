using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerMove = 5f;
    public float playerJump = 7f;
    public bool isDie = false;

    protected Rigidbody2D rigid;
    protected bool isGrounded = false;

    // 캐릭터 이동을 위한 입력 키 설정
    private string horizontalInput;
    private string verticalInput;
    private string jumpInput;

    // 입력 값으로 키를 전달받을 수 있도록 설정
    public void SetControlKeys(string horizontal, string vertical, string jump)
    {
        horizontalInput = horizontal;
        verticalInput = vertical;
        jumpInput = jump;
    }

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        PlayerMove();
        PlayerJump();
    }

    public virtual void PlayerMove()
    {
        // 해당 입력 키에 따라 이동
        float h = Input.GetAxis(horizontalInput);
        rigid.velocity = new Vector2(h * playerMove, rigid.velocity.y);  // 수평 이동
    }

    public virtual void PlayerJump()
    {
        if (Input.GetButtonDown(jumpInput) && isGrounded)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, playerJump);  // 수직 점프
            isGrounded = false;
        }
    }

    public virtual void PlayerCollision()
    {
        // 공통 충돌 처리
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        PlayerCollision();
    }
}