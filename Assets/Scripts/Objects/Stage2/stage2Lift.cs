using UnityEngine;

public class stage2Lift : MonoBehaviour
{
    public float moveSpeed = 2f; // ����Ʈ �̵� �ӵ�
    public float lowerYPosition = 0f; // ����Ʈ�� ���� y ��ġ

    private bool isPlayerOnLift = false;
    private bool isMovingDown = false;

    private void Update()
    {
        // �÷��̾ ž�� ���̰� ����Ʈ�� �������� ���¶��
        if (isPlayerOnLift && isMovingDown)
        {
            // �Ʒ��� �̵�
            Vector3 newPosition = transform.position;
            newPosition.y -= moveSpeed * Time.deltaTime;

            // Ư�� ��ġ���� �̵� �� ����
            if (newPosition.y <= lowerYPosition)
            {
                newPosition.y = lowerYPosition;
                isMovingDown = false; // ����
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

    // Ʈ���� ������ ���� ž�� ���� Ȯ��
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnLift = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnLift = false;
        }
    }
}