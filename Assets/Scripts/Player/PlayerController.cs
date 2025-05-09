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

    //InputManager���� Ű ���� �� ������
    protected abstract string GetHorizontalAxis();
    protected abstract string GetJumpButton();
    protected virtual void Update()
    {
        //Ű �Ҵ�
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
        // ���� �浹���� ��, isGrounded�� true�� ����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // ���� �������� ��, isGrounded�� false�� ����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}