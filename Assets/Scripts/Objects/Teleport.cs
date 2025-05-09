using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;  // 텔레포트할 위치 (두 번째 포탈)

    // 플레이어가 포탈에 들어가면 텔레포트
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // "Player" 태그를 가진 오브젝트만 반응
        {
            TeleportPlayer(other.gameObject);  // 플레이어 텔레포트
        }
    }

    // 플레이어 텔레포트 함수
    void TeleportPlayer(GameObject player)
    {
        player.transform.position = teleportTarget.position;  // 지정된 위치로 이동
        Debug.Log($"{player.name}가 포탈을 통해 텔레포트되었습니다.");
    }
}
