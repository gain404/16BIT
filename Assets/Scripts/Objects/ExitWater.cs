using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWater : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (collision.gameObject.CompareTag("Player"))
        {
            IsExitForFirePlayer(player.playerType); // PlayerType�� Fire, Water �߰� �ʿ�
        }
    }

    internal bool IsExitForFirePlayer(PlayerType playerType)  // PlayerType�� Fire, Water �߰� �ʿ�
    {
        switch (playerType)
        {
            case PlayerType.Fire:
                Debug.Log("�Ҳ� ĳ���ʹ� �� Ż��η� Ż���� �� �����ϴ�.");
                return true;
            case PlayerType.Water:
                Debug.Log("�� ĳ���� Ż��");
                return false;
            default:
                Debug.LogError("�߻��� �� ���� �����Դϴ�.");
                return false;
        }
    }
}
