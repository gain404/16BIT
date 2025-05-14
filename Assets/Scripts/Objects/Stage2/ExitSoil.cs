using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSoil : MonoBehaviour
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

    internal bool IsExitForFirePlayer(PlayerType playerType)
    {
        switch (playerType)
        {
            case PlayerType.Soil:
                Debug.Log("����� ���� ����!");
                return true;
            case PlayerType.Thunder:
                Debug.Log("������̴� ������� ���� �� �� �����ϴ�.");
                return false;
            default:
                Debug.LogError("�߻��� �� ���� �����Դϴ�.");
                return false;
        }
    }
}
