using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor2NPC : MonoBehaviour
{
    private bool isPush;
    private Escalator escalator;

    private void Awake()
    {
        escalator = FindObjectOfType<Escalator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPush = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPush = false;
        }
    }

    private void Update()
    {
        talkNPC();
    }

    private void talkNPC()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPush)
        {
            //��? ȸ��Գ� ����� �Ƴ�.
            //���̰�, �� ������ �� �ö���� �ֳ�!
            //�����÷����� ������ �� �ٰ�. �� �ö����!
            //�̶��~ UI��ȯ
            Debug.Log("npc�� ��ȭ");
            escalator.InvokeRepeating(nameof(Escalator.PlayEscalator), 1f, 2f);
            Invoke(nameof(StopEscalator), 10f);
        }
    }

    private void StopEscalator()
    {
        escalator.CancelInvoke(nameof(Escalator.PlayEscalator));
    }
}
