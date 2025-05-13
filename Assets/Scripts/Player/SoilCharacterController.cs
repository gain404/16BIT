using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SoilCharacterController : PlayerController
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
