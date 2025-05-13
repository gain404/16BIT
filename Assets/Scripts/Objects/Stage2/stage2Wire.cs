using UnityEngine;

public class stage2Wire : MonoBehaviour
{
    public void Interact(PlayerController player)
    {
        switch (player.playerType)
        {
            case PlayerType.Soil:
                Debug.Log("흙냥이는 전선을 안전하게 지나갑니다.");
                // 아무 일 없음
                break;

            case PlayerType.Thunder:
                Debug.Log("전기냥이가 전선에 닿아 폭발! 게임 오버");
                // GameManager.Instance.GameOver(); // 실제 게임 오버 처리
                // 또는 player.Die();
                break;
        }
    }
}