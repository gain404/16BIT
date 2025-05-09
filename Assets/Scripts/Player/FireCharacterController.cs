using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCharacterController : PlayerController
{
    // Fire 전용 이동방식
    public override void PlayerMove()
    {
        base.PlayerMove();  // 기본 PlayerMove 호출
        // Fire 전용 이동 처리 (필요시 추가로 Fire 캐릭터만의 이동 방식을 적용)
    }

    // Fire 전용 점프 (점프 특성 변경이 필요한 경우 수정)
    public override void PlayerJump()
    {
        base.PlayerJump();  // 기본 PlayerJump 호출
        // Fire 전용 점프 처리 (필요시 추가로 Fire 캐릭터만의 점프 특성 적용)
    }

    // Fire 전용 충돌 처리
    public override void PlayerCollision()
    {
        base.PlayerCollision();  // 기본 충돌 처리 호출
        // Fire 캐릭터 특성에 맞는 충돌 처리 추가
        Debug.Log("Fire Collision Detected");

        // 예시로 Fire 캐릭터와 충돌 시 특정 행동 추가
        // 예: Fire 캐릭터가 불에 닿은 오브젝트와 충돌했을 때 데미지를 주거나, 불을 켜는 등
    }
}
