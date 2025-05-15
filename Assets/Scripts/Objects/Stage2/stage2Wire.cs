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
        Debug.Log("������ ����");
        // if (!other.gameObject.CompareTag("Player")) return;

        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        // if (player == null) return;

        switch (player.playerType)
        {

            case PlayerType.Soil:
                Debug.Log("����̴� ������ �����ϰ� �������ϴ�.");
                // �ƹ� �� ����
                break;

            case PlayerType.Thunder:
                GameManager.instance.GameOver();
                Debug.Log("������̰� ������ ��� ����! ���� ����");
                // GameManager.Instance.GameOver(); // ���� ���� ���� ó��
                // �Ǵ� player.Die();
                break;
        }
    }
}