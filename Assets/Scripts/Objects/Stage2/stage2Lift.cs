using UnityEngine;

public class stage2Lift : MonoBehaviour
{
    public float moveSpeed = 2f; // ����Ʈ �̵� �ӵ�
    public float lowerYPosition = 1f; // ����Ʈ�� ���� y ��ġ

    private bool isPlayerOnLift = false;
    private bool isMovingDown = false;

    private void Update()
    {
        if (isPlayerOnLift && isMovingDown)
        {
            Vector3 newPosition = transform.position;
            newPosition.y -= moveSpeed * Time.deltaTime;

            if (newPosition.y <= lowerYPosition)
            {
                newPosition.y = lowerYPosition;
                isMovingDown = false;
            }

            transform.position = newPosition;
        }
    }

    public void Interact(PlayerController player)
    {
        if (isPlayerOnLift)
        {
            Debug.Log("����Ʈ�� Ÿ�� �������ϴ�.");
            isMovingDown = true;
        }
        else
        {
            Debug.Log("�÷��̾ ����Ʈ�� ž������ �ʾҽ��ϴ�.");
        }
    }

    // �浹�� ���� ž�� ���� Ȯ��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnLift = true;

            if (collision.gameObject.TryGetComponent<PlayerController>(out var player))
            {
                Interact(player);
            }
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