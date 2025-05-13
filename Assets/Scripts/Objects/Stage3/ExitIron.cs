using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitIron : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        GameManager.instance.playersAtExit++; // ���� �Ŵ����� Ż�� ���θ� ����
        Debug.Log("Ż���� �÷��̾� ��: " + GameManager.instance.playersAtExit);
        if (collision.gameObject.CompareTag("Player"))
        {
            IsExitForFirePlayer(player.playerType);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("OnTriggerExit2D");
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        GameManager.instance.playersAtExit--; // ���� �Ŵ����� Ż�� ���θ� ����
        Debug.Log("Ż���� �÷��̾� ��: " + GameManager.instance.playersAtExit);
    }

    internal bool IsExitForFirePlayer(PlayerType playerType)  // PlayerType�� Fire, Water �߰� �ʿ�
    {
        switch (playerType)
        {
            case PlayerType.Iron:
                Debug.Log("ö ����̴� Ż��!");
                return true;
            case PlayerType.Light:
                Debug.Log("�� ����̰� ö Ż��η� Ż���� �� �����ϴ�.");
                return false;
            default:
                Debug.LogError("�߻��� �� ���� �����Դϴ�.");
                return false;
        }
    }
}
