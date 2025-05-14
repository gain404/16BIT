using UnityEngine;

public class stage2Puddle : MonoBehaviour
{
    private enum PuddleState
    {
        Normal,     // �ʱ� ����
        Muddy,      // ������ ���� (����� ��� ����)
        Dried       // ���� �������� ��� ����
    }

    private PuddleState currentState = PuddleState.Normal;
    private Renderer puddleRenderer;

    // ���� ���� (���� ����)
    public Color normalColor = Color.blue;
    public Color muddyColor = new Color(0.4f, 0.2f, 0f); // ����
    public Color driedColor = new Color(0.8f, 0.7f, 0.5f); // �����ִ� ���

    void Start()
    {
        puddleRenderer = GetComponent<Renderer>();
        UpdatePuddleVisual();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerController player = other.GetComponent<PlayerController>();
        if (player == null) return;

        switch (player.playerType)
        {
            case PlayerType.Soil:
                HandleSoilInteraction();
                break;
            case PlayerType.Thunder:
                HandleThunderInteraction();
                break;
        }
    }

    private void HandleSoilInteraction()
    {
        if (currentState == PuddleState.Normal)
        {
            Debug.Log("����̰� �������̸� �������� �ٲٰ� �����ϴ�.");
            currentState = PuddleState.Dried;
            UpdatePuddleVisual();
        }
    }

    private void HandleThunderInteraction()
    {
        if (currentState == PuddleState.Normal)
        {
            Debug.Log("�������̰� �������̿� ��� ���� ����!");
            // GameManager.Instance.GameOver(); // �ʿ� �� ���� ���� ���� ����
        }
        else if (currentState == PuddleState.Dried)
        {
            Debug.Log("�������̰� ���� �ִ� �����̸� �����ϰ� ����մϴ�.");
        }
    }

    private void UpdatePuddleVisual()
    {
        if (puddleRenderer == null) return;

        switch (currentState)
        {
            case PuddleState.Normal:
                puddleRenderer.material.color = normalColor;
                break;
            case PuddleState.Dried:
                puddleRenderer.material.color = driedColor;
                break;
        }
    }
}
