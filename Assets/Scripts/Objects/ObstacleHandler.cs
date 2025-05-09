using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    [SerializeField] private ObstacleType obstacleType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>(); //PlayerController가 Instance로 싱글톤화시 수정 필요
        if (player != null)
        {
           // if (IsDangerForPlayer(player.playerType)) //PlayerController에서 public PlayerType playerType형식으로 지정 필요
            {
                Destroy(player.gameObject); // 위험하면 파괴
            }
        }
    }

    private bool IsDangerForPlayer(PlayerType playerType)
    {
        switch (obstacleType)
        {
            case ObstacleType.FirePuddle:
           //     return playerType != PlayerType.Fire; //같은 타입이 아니면 플레이어 Destroy처리
            case ObstacleType.WaterPuddle:
           //     return playerType != PlayerType.Water;
            case ObstacleType.PoisonPuddle:
                return true; //독 타일은 얄짤없이 플레이어 Destroy처리
            default:
                Debug.LogError("뭐야 이거 어떻게 닿았어");
                return false;
        }
    }
}

enum ObstacleType
{
    FirePuddle,
    WaterPuddle,
    PoisonPuddle
}

