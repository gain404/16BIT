using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitIron : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        GameManager.instance.playersAtExit++; // 게임 매니저에 탈출 여부를 전달
        Debug.Log("탈출한 플레이어 수: " + GameManager.instance.playersAtExit);
        if (collision.gameObject.CompareTag("Player"))
        {
            IsExitForFirePlayer(player.playerType);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("OnTriggerExit2D");
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        GameManager.instance.playersAtExit--; // 게임 매니저에 탈출 여부를 전달
        Debug.Log("탈출한 플레이어 수: " + GameManager.instance.playersAtExit);
    }

    internal bool IsExitForFirePlayer(PlayerType playerType)  // PlayerType에 Fire, Water 추가 필요
    {
        switch (playerType)
        {
            case PlayerType.Iron:
                Debug.Log("철 고양이는 탈출!");
                return true;
            case PlayerType.Light:
                Debug.Log("빛 고양이가 철 탈출로로 탈출할 수 없습니다.");
                return false;
            default:
                Debug.LogError("발생할 수 없는 오류입니다.");
                return false;
        }
    }
}
