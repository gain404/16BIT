using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage2Lift_Right : MonoBehaviour
{
    public float moveSpeed = 2f; // ����Ʈ �̵� �ӵ�
    public float lowerYPosition = 0f; // ����Ʈ�� ���� y ��ġ

    private bool isPlayerOnLift = false;
    private bool isMovingUp = false;

    private void Update()
    {
        // �÷��̾ ž�� ���̰� ����Ʈ�� �������� ���¶��
        if (isPlayerOnLift && isMovingUp)
        {
            // ���� �̵�
            Vector3 newPosition = transform.position;
            newPosition.y += moveSpeed * Time.deltaTime;

            // Ư�� ��ġ���� �̵� �� ����
            if (newPosition.y >= lowerYPosition)
            {
                newPosition.y = lowerYPosition;
                isMovingUp = false; // ����
            }

            transform.position = newPosition;
        }
    }

    public void Interact(PlayerController player)
    {
        if (isPlayerOnLift)
        {
            Debug.Log("����Ʈ�� Ÿ�� �ö󰩴ϴ�.");
            isMovingUp = true;
        }
        else
        {
            Debug.Log("�÷��̾ ����Ʈ�� ž������ �ʾҽ��ϴ�.");
        }
    }

    // Ʈ���� ������ ���� ž�� ���� Ȯ��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnLift = true;
            Interact(collision.gameObject.GetComponent<PlayerController>());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnLift = false;
        }
    }
}
