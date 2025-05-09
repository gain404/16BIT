using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWater : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>(); //PlayerController가 Instance로 싱글톤화시 수정 필요
        if (player != null)
        {
            //    IsExitForFirePlayer(player.playerType); // PlayerType에 Fire, Water 추가 필요
        }
    }

    internal bool IsExitForWaterPlayer(PlayerType playerType)  // PlayerType에 Fire, Water 추가 필요
    {
        /*
        switch (playerType)
        {
            case PlayerType.Fire:
                Debug.Log("불꽃 캐릭터는 물 탈출로로 탈출할 수 없습니다");
                return true;
            case PlayerType.Water:
                Debug.Log("물 캐릭터 탈출");
                return false;
            default:
                Debug.LogError("발생할 수 없는 오류입니다.");
                return false;
        }
        */
        return false; // 임시로 false를 반환합니다. 나중에 수정 필요
    }
}
