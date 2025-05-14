using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2TWireButton : MonoBehaviour
{
    public GameObject targetWire; // 무력화할 전선 오브젝트 (stage2Wire_2)
    public Color driedColor = new Color(1f, 1f, 1f, 0.3f); // 흰색 반투명
    public Color OriginColor = new Color(1f, 1f, 1f, 1f); // 흰색 반투명


    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        SpriteRenderer sr = targetWire.GetComponent<SpriteRenderer>();
        if (player == null) return;

        if (player.playerType == PlayerType.Soil)
        {
            Debug.Log("흙 고양이가 버튼을 눌렀습니다. 다음 전선이 비활성화됩니다.");

            if (targetWire != null)
            {
                Collider2D wireCollider = targetWire.GetComponent<Collider2D>();
                if (wireCollider != null)
                {
                    // 전선을 트리거로 만들어 통과하게 함
                    wireCollider.isTrigger = true;
                    sr.color = driedColor;

                    // 또는 충돌 자체를 비활성화하고 싶다면
                    // wireCollider.enabled = false;
                }
            }
        }
    }

}

