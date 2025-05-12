using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderButton : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null)
            return;

        if (collision.collider.TryGetComponent<PlayerController>(out var pt))
        {
            if (pt.playerType == PlayerType.Thunder)
            {
                Debug.Log("thunder타입 플레이어와 충돌");
                //여기에 에스컬레이터 움직이는 로직 추가
            }
        }
    }
}
