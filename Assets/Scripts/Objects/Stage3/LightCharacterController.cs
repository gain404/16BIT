using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCharacterController : PlayerController
{
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
}
