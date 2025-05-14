using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSoil : MonoBehaviour
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

    internal bool IsExitForFirePlayer(PlayerType playerType)
    {
        switch (playerType)
        {
            case PlayerType.Soil:
                Debug.Log("흙냥이 가출 종료!");
                return true;
            case PlayerType.Thunder:
                Debug.Log("전기냥이는 흙냥이의 집에 들어갈 수 없습니다.");
                return false;
            default:
                Debug.LogError("발생할 수 없는 오류입니다.");
                return false;
        }
    }
}
