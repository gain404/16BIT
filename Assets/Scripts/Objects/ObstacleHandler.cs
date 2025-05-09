using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    [SerializeField] private ObstacleType obstacleType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>(); //PlayerController�� Instance�� �̱���ȭ�� ���� �ʿ�
        if (player != null)
        {
           // if (IsDangerForPlayer(player.playerType)) //PlayerController���� public PlayerType playerType�������� ���� �ʿ�
            {
                Destroy(player.gameObject); // �����ϸ� �ı�
            }
        }
    }

    private bool IsDangerForPlayer(PlayerType playerType)
    {
        switch (obstacleType)
        {
            case ObstacleType.FirePuddle:
           //     return playerType != PlayerType.Fire; //���� Ÿ���� �ƴϸ� �÷��̾� Destroyó��
            case ObstacleType.WaterPuddle:
           //     return playerType != PlayerType.Water;
            case ObstacleType.PoisonPuddle:
                return true; //�� Ÿ���� ��©���� �÷��̾� Destroyó��
            default:
                Debug.LogError("���� �̰� ��� ��Ҿ�");
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

