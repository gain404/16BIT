using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ThunderCharacterController : PlayerController
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
