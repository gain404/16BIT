using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCharacterController : PlayerController
{
    protected override void Awake()
    {
        base.Awake();
        // Water 전용 초기화
    }

    public override void PlayerCollision()
    {
        base.PlayerCollision();
        // Water 전용 충돌 처리
    }
}