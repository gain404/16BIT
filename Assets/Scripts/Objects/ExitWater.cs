using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWater : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>(); //PlayerController�� Instance�� �̱���ȭ�� ���� �ʿ�
        if (player != null)
        {
            //    IsExitForFirePlayer(player.playerType); // PlayerType�� Fire, Water �߰� �ʿ�
        }
    }

    internal bool IsExitForWaterPlayer(PlayerType playerType)  // PlayerType�� Fire, Water �߰� �ʿ�
    {
        /*
        switch (playerType)
        {
            case PlayerType.Fire:
                Debug.Log("�Ҳ� ĳ���ʹ� �� Ż��η� Ż���� �� �����ϴ�");
                return true;
            case PlayerType.Water:
                Debug.Log("�� ĳ���� Ż��");
                return false;
            default:
                Debug.LogError("�߻��� �� ���� �����Դϴ�.");
                return false;
        }
        */
        return false; // �ӽ÷� false�� ��ȯ�մϴ�. ���߿� ���� �ʿ�
    }
}
