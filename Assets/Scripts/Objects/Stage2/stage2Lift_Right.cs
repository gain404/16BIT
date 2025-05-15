using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage2Lift_Right : MonoBehaviour
{
    public float moveSpeed = 2f; // 리프트 이동 속도
    public float lowerYPosition = 0f; // 리프트가 멈출 y 위치

    private bool isPlayerOnLift = false;
    private bool isMovingUp = false;

    private void Update()
    {
        // 플레이어가 탑승 중이고 리프트가 내려가는 상태라면
        if (isPlayerOnLift && isMovingUp)
        {
            // 위로 이동
            Vector3 newPosition = transform.position;
            newPosition.y += moveSpeed * Time.deltaTime;

            // 특정 위치까지 이동 시 정지
            if (newPosition.y >= lowerYPosition)
            {
                newPosition.y = lowerYPosition;
                isMovingUp = false; // 멈춤
            }

            transform.position = newPosition;
        }
    }

    public void Interact(PlayerController player)
    {
        if (isPlayerOnLift)
        {
            Debug.Log("리프트를 타고 올라갑니다.");
            isMovingUp = true;
        }
        else
        {
            Debug.Log("플레이어가 리프트에 탑승하지 않았습니다.");
        }
    }

    // 트리거 영역을 통해 탑승 여부 확인
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
