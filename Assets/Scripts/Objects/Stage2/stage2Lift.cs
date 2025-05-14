using UnityEngine;

public class stage2Lift : MonoBehaviour
{
    public float moveSpeed = 2f; // 리프트 이동 속도
    public float lowerYPosition = 1f; // 리프트가 멈출 y 위치

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
            Debug.Log("리프트를 타고 내려갑니다.");
            isMovingDown = true;
        }
        else
        {
            Debug.Log("플레이어가 리프트에 탑승하지 않았습니다.");
        }
    }

    // 충돌을 통해 탑승 여부 확인
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