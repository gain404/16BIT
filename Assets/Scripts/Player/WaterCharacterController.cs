using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCharacterController : PlayerController
{
    protected override string GetHorizontalAxis()
    {
        return "WaterHorizontal";
    }

    protected override string GetJumpButton()
    {
        return "WaterJump";
    }
}