using UnityEngine;


public class stage2Vent : MonoBehaviour
{
    public void Interact(PlayerController player)
    {
        switch (player.playerType)
        {
            case PlayerType.Soil:
                Debug.Log("����̰� ȯǳ���� ��� ���� ����!");
                // GameManager.Instance.GameOver(); // ���� ���� ���� ó��
                break;

            case PlayerType.Thunder:
                Debug.Log("������̰� ȯǳ���� �����ϰ� ����մϴ�.");
                // �ƹ� �ൿ�� �� �ص� ��
                break;
        }
    }
}