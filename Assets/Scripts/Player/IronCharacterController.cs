using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronCharacterController : PlayerController
{
    protected override string GetHorizontalAxis()
    {
        return "FireHorizontal";
    }

    protected override string GetJumpButton()
    {
        return "FireJump";
    }
}
