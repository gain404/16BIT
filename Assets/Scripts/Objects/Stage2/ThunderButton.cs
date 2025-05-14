using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderButton : MonoBehaviour
{
    private Escalator escalator;

    private void Awake()
    {
        escalator = FindObjectOfType<Escalator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<PlayerController>(out var pt))
        {
            if (pt.playerType == PlayerType.Thunder)
            {
                Debug.Log("thunder타입 플레이어와 충돌");
                escalator.InvokeRepeating(nameof(Escalator.PlayEscalator), 0f, 2f);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (escalator != null)
        {
            escalator.CancelInvoke(nameof(Escalator.PlayEscalator));

        }
    }

}
