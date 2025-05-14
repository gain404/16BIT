using UnityEngine;

public class stage2Vent : MonoBehaviour
{
    private bool isSafeForSoil = false; // ����̰� ��� ������ ��������

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
                    Debug.Log("����̰� ȯǳ���� ��� ���� ����!");
                    GameManager.instance.GameOver(); // ���� ���� ó��
                }
                else
                {
                    Debug.Log("��������: ����̰� ȯǳ���� ����մϴ�.");
                }
                break;

            case PlayerType.Thunder:
                Debug.Log("������̰� ȯǳ���� �����ϰ� ����մϴ�.");
                break;
        }
    }

    // ThunderButton���� ȣ���� �޼���
    public void SetSafeForSoil(bool safe)
    {
        isSafeForSoil = safe;
    }
}