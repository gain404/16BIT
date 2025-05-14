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

<<<<<<< HEAD
    // �浹�� ���� ž�� ���� Ȯ��
=======
    // Ʈ���� ������ ���� ž�� ���� Ȯ��
>>>>>>> 5bde79f66e348f366aaffa0ef9feacd5483270b4
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnLift = true;
<<<<<<< HEAD

            if (collision.gameObject.TryGetComponent<PlayerController>(out var player))
            {
                Interact(player);
            }
=======
            Interact(collision.gameObject.GetComponent<PlayerController>());
>>>>>>> 5bde79f66e348f366aaffa0ef9feacd5483270b4
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