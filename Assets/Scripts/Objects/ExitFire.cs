using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFire : MonoBehaviour
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
                Debug.Log("�Ҳ� ĳ���� Ż��");
                return true;
            case PlayerType.Water:
                Debug.Log("�� ĳ���ʹ� �Ҳ� Ż��η� Ż���� �� �����ϴ�.");
                return false;
            default:
                Debug.LogError("�߻��� �� ���� �����Դϴ�.");
                return false;
        }
    }
}
