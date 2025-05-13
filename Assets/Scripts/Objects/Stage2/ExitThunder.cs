using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitThunder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (collision.gameObject.CompareTag("Player"))
        {
            IsExitForFirePlayer(player.playerType);
        }
    }

    internal bool IsExitForFirePlayer(PlayerType playerType)
    {
        switch (playerType)
        {
            case PlayerType.Thunder:
                Debug.Log("전기냥이 집으로 안착!");
                return true;
            case PlayerType.Soil:
                Debug.Log("흙냥이는 전기냥이 집으로 들어올 수 없습니다.");
                return false;
            default:
                Debug.LogError("발생할 수 없는 오류입니다.");
                return false;
        }
    }
}
