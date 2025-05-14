using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2TWireButton : MonoBehaviour
{
    public GameObject targetWire; // ����ȭ�� ���� ������Ʈ (stage2Wire_2)
    public Color driedColor = new Color(1f, 1f, 1f, 0.3f); // ��� ������
    public Color OriginColor = new Color(1f, 1f, 1f, 1f); // ��� ������


    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        SpriteRenderer sr = targetWire.GetComponent<SpriteRenderer>();
        if (player == null) return;

        if (player.playerType == PlayerType.Soil)
        {
            Debug.Log("�� ����̰� ��ư�� �������ϴ�. ���� ������ ��Ȱ��ȭ�˴ϴ�.");

            if (targetWire != null)
            {
                Collider2D wireCollider = targetWire.GetComponent<Collider2D>();
                if (wireCollider != null)
                {
                    // ������ Ʈ���ŷ� ����� ����ϰ� ��
                    wireCollider.isTrigger = true;
                    sr.color = driedColor;

                    // �Ǵ� �浹 ��ü�� ��Ȱ��ȭ�ϰ� �ʹٸ�
                    // wireCollider.enabled = false;
                }
            }
        }
    }

}

