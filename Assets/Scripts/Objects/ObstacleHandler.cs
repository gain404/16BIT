using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    [SerializeField] private ObstacleType obstacleType;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");

        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            if (IsDangerForPlayer(player.playerType)) //PlayerController���� public PlayerType playerType�������� ���� �ʿ�
            {
                GameManager.instance.GameOver();
               // Destroy(player.gameObject); // �����ϸ� �ı�
            }
        }
    }

    private bool IsDangerForPlayer(PlayerType playerType)
    {
        switch (obstacleType)
        {
            case ObstacleType.FirePuddle:
                Debug.Log(playerType);
                return playerType != PlayerType.Fire; //���� Ÿ���� �ƴϸ� �÷��̾� Destroyó��
            case ObstacleType.WaterPuddle:
                Debug.Log(playerType);
                return playerType != PlayerType.Water;
            case ObstacleType.PoisonPuddle:
                Debug.Log(playerType);
                return true; //�� Ÿ���� ��©���� �÷��̾� Destroyó��
            case ObstacleType.Thorn:
                Debug.Log("���ÿ� ��ҽ��ϴ�.");
                return true;

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
    PoisonPuddle,
    Thorn
}

