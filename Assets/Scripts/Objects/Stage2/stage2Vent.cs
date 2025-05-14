using UnityEngine;

public class stage2Vent : MonoBehaviour
{
    private bool isSafeForSoil = false; // 흙냥이가 통과 가능한 상태인지

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent<PlayerController>(out var player))
        {
            Interact(player);
        }
    }

    public void Interact(PlayerController player)
    {
        switch (player.playerType)
        {
            case PlayerType.Soil:
                if (!isSafeForSoil)
                {
                    Debug.Log("흙냥이가 환풍구에 닿아 게임 오버!");
                    GameManager.instance.GameOver(); // 게임 오버 처리
                }
                else
                {
                    Debug.Log("안전상태: 흙냥이가 환풍구를 통과합니다.");
                }
                break;

            case PlayerType.Thunder:
                Debug.Log("전기냥이가 환풍구를 안전하게 통과합니다.");
                break;
        }
    }

    // ThunderButton에서 호출할 메서드
    public void SetSafeForSoil(bool safe)
    {
        isSafeForSoil = safe;
    }
}