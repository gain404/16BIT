using UnityEngine;


public class stage2Vent : MonoBehaviour
{
    public void Interact(PlayerController player)
    {
        switch (player.playerType)
        {
            case PlayerType.Soil:
                Debug.Log("흙냥이가 환풍구에 닿아 게임 오버!");
                // GameManager.Instance.GameOver(); // 실제 게임 오버 처리
                break;

            case PlayerType.Thunder:
                Debug.Log("전기냥이가 환풍구를 안전하게 통과합니다.");
                // 아무 행동도 안 해도 됨
                break;
        }
    }
}