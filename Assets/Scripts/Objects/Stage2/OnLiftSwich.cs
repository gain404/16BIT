using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLiftSwich : MonoBehaviour
{
    public GameObject targetWire; // ����ȭ�� ���� ������Ʈ (stage2Wire_2)

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        SpriteRenderer sr = targetWire.GetComponent<SpriteRenderer>();
        if (player == null) return;

            Debug.Log("�� ����̰� ��ư�� �������ϴ�. ���� ������ ��Ȱ��ȭ�˴ϴ�.");

            if (targetWire != null)
            {
                Collider2D wireCollider = targetWire.GetComponent<Collider2D>();
                if (wireCollider != null)
                {
                    // ������ Ʈ���ŷ� ����� ����ϰ� ��
                    wireCollider.gameObject.SetActive(true);

                    // �Ǵ� �浹 ��ü�� ��Ȱ��ȭ�ϰ� �ʹٸ�
                    // wireCollider.enabled = false;
                }
            }
    }
}

