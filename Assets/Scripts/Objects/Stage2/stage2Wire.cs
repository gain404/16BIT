using UnityEngine;

public class stage2Wire : MonoBehaviour
{
    public void Interact(PlayerController player)
    {
        switch (player.playerType)
        {
            case PlayerType.Soil:
                Debug.Log("����̴� ������ �����ϰ� �������ϴ�.");
                // �ƹ� �� ����
                break;

            case PlayerType.Thunder:
                Debug.Log("������̰� ������ ��� ����! ���� ����");
                // GameManager.Instance.GameOver(); // ���� ���� ���� ó��
                // �Ǵ� player.Die();
                break;
        }
    }
}