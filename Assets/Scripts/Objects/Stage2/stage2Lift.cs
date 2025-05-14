using UnityEngine;

public class stage2Lift : MonoBehaviour
{
    public float moveSpeed = 2f; // 리프트 이동 속도
    public float lowerYPosition = 1f; // 리프트가 멈출 y 위치

    private bool isPlayerOnLift = false;
    private bool isMovingDown = false;

    private void Update()
    {
        // 플레이어가 탑승 중이고 리프트가 내려가는 상태라면
        if (isPlayerOnLift && isMovingDown)
        {
            // 아래로 이동
            Vector3 newPosition = transform.position;
            newPosition.y -= moveSpeed * Time.deltaTime;

            // 특정 위치까지 이동 시 정지
            if (newPosition.y <= lowerYPosition)
            {
                newPosition.y = lowerYPosition;
                isMovingDown = false; // 멈춤
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

    // 트리거 영역을 통해 탑승 여부 확인
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnLift = true;
            Interact(other.GetComponent<PlayerController>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnLift = false;
        }
    }
}