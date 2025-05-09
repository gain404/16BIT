using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;  // �ڷ���Ʈ�� ��ġ (�� ��° ��Ż)

    // �÷��̾ ��Ż�� ���� �ڷ���Ʈ
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // "Player" �±׸� ���� ������Ʈ�� ����
        {
            TeleportPlayer(other.gameObject);  // �÷��̾� �ڷ���Ʈ
        }
    }

    // �÷��̾� �ڷ���Ʈ �Լ�
    void TeleportPlayer(GameObject player)
    {
        player.transform.position = teleportTarget.position;  // ������ ��ġ�� �̵�
        Debug.Log($"{player.name}�� ��Ż�� ���� �ڷ���Ʈ�Ǿ����ϴ�.");
    }
}
