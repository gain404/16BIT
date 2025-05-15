using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCharacterController : PlayerController
{
    private bool isGroundedByGravity()
    {
        // �߷� ���¿� ���� ����ĳ��Ʈ ���� ����
        Vector2 gravityDir = GravityHandler.instance.gravityReversed ? Vector2.up : Vector2.down;

        // �߷� ���⿡ ���� BoxCast ���� ����
        return Physics2D.BoxCast(transform.position, groundCheck, 0, gravityDir, castDistance, groundLayer);
    }

    protected override string GetHorizontalAxis()
    {
        return "FireHorizontal";
    }

    protected override string GetJumpButton()
    {
        return "FireJump";
    }

    public override void Jump()
    {
        if (GravityHandler.instance.gravityReversed)
        {
            _rigidbody.AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);
        }
        else
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    protected override void Update()
    {
        float horizontal = Input.GetAxisRaw(GetHorizontalAxis());
        Move(horizontal);

        if (isGroundedByGravity() && Input.GetButtonDown(GetJumpButton()))
        {
            Jump();
        }

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

        animator.SetBool("isRunning", isMoving);
    }
}
