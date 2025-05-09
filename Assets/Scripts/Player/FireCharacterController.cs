using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCharacterController : PlayerController
{
    protected override string GetHorizontalAxis()
    {
        return "FireHorizontal";
    }

    protected override string GetJumpButton()
    {
        Debug.Log("บา มกวม");
        return "FireJump";
    }
}
