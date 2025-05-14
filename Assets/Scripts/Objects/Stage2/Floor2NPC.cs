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
            //어? 회장님네 고양이 아냐.
            //아이고, 한 마리가 못 올라오고 있네!
            //에스컬레이터 전원을 켜 줄게. 얼른 올라오렴!
            //이라는~ UI소환
            Debug.Log("npc와 대화");
            escalator.InvokeRepeating(nameof(Escalator.PlayEscalator), 1f, 2f);
            Invoke(nameof(StopEscalator), 10f);
        }
    }

    private void StopEscalator()
    {
        escalator.CancelInvoke(nameof(Escalator.PlayEscalator));
    }
}
