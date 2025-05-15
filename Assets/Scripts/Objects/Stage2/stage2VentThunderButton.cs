using UnityEngine;

public class stage2VentThunderButton : MonoBehaviour
{
    private stage2Vent vent;

    private void Awake()
    {
        vent = FindObjectOfType<stage2Vent>(); // ���� �����ϴ� ȯǳ�� ������Ʈ ����
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<PlayerController>(out var pt))
        {
            if (pt.playerType == PlayerType.Thunder)
            {
                Debug.Log("thunderŸ�� �÷��̾�� �浹");

                if (vent != null)
                    vent.SetSafeForSoil(true); // ȯǳ���� �� ��� ���
            }
        }
    }
}