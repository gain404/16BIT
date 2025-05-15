using UnityEngine;

public class stage2Wire : MonoBehaviour
{
    
    private Renderer electricWireRenderer;

    private void Start()
    {
        electricWireRenderer = GetComponent<Renderer>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("전선에 닿음");
        // if (!other.gameObject.CompareTag("Player")) return;

        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        // if (player == null) return;

        switch (player.playerType)
        {

            case PlayerType.Soil:
                Debug.Log("흙냥이는 전선을 안전하게 지나갑니다.");
                // 아무 일 없음
                break;

            case PlayerType.Thunder:
                GameManager.instance.GameOver();
                Debug.Log("전기냥이가 전선에 닿아 폭발! 게임 오버");
                // GameManager.Instance.GameOver(); // 실제 게임 오버 처리
                // 또는 player.Die();
                break;
        }
    }
}