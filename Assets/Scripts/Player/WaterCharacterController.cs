using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCharacterController : PlayerController
{
    protected override void Awake()
    {
        base.Awake();
        // Water ���� �ʱ�ȭ
    }

    public override void PlayerCollision()
    {
        base.PlayerCollision();
        // Water ���� �浹 ó��
    }
}