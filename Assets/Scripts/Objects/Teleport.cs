using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;  // �ڷ���Ʈ�� ��ġ (�� ��° ��Ż)

    public int teleportCoolTime = 1;
    
    // �÷��̾ ��Ż�� ���� �ڷ���Ʈ
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && GameManager.instance.teleportEnable)  // "Player" �±׸� ���� ������Ʈ�� ����
        {
            GameManager.instance.teleportEnable = false;
            TeleportPlayer(other.gameObject);  // �÷��̾� �ڷ���Ʈ
            Invoke("OnTeleportCoolTime", teleportCoolTime);
        }
    }

    // �÷��̾� �ڷ���Ʈ �Լ�
    void TeleportPlayer(GameObject player)
    {
        player.transform.position = teleportTarget.position;  // ������ ��ġ�� �̵�
        Debug.Log($"{player.name}�� ��Ż�� ���� �ڷ���Ʈ�Ǿ����ϴ�.");
    }

    void OnTeleportCoolTime()
    {
        GameManager.instance.teleportEnable = true;
    }

}
