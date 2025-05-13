using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor2NPC : MonoBehaviour
{
    private bool isPush;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPush = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPush = false;
        }
    }
    private void talkNPC()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPush)
        {
            //��? ȸ��Գ� ����� �Ƴ�.
            //���̰�, �� ������ �� �ö���� �ֳ�!
            //�����÷����� ������ �� �ٰ�. �� �ö����!
            //�̶��~ UI��ȯ
            InvokeRepeating(nameof(Escalator.PlayEscalator), 0f, 2f);
        }
    }
}
