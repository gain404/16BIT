using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerMove = 5f;
    public float playerJump = 7f;
    public bool isDie = false;

    protected Rigidbody2D rigid;
    protected bool isGrounded = false;

    // ĳ���� �̵��� ���� �Է� Ű ����
    private string horizontalInput;
    private string verticalInput;
    private string jumpInput;

    // �Է� ������ Ű�� ���޹��� �� �ֵ��� ����
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
        // �ش� �Է� Ű�� ���� �̵�
        float h = Input.GetAxis(horizontalInput);
        rigid.velocity = new Vector2(h * playerMove, rigid.velocity.y);  // ���� �̵�
    }

    public virtual void PlayerJump()
    {
        if (Input.GetButtonDown(jumpInput) && isGrounded)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, playerJump);  // ���� ����
            isGrounded = false;
        }
    }

    public virtual void PlayerCollision()
    {
        // ���� �浹 ó��
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