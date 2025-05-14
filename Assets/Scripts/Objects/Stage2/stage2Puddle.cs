using UnityEngine;

public class stage2Puddle : MonoBehaviour
{
    private enum PuddleState
    {
        Normal,     // 초기 상태
        Muddy,      // 흙탕물 상태 (현재는 사용 안함)
        Dried       // 말라서 번개냥이 통과 가능
    }

    private PuddleState currentState = PuddleState.Normal;
    private Renderer puddleRenderer;

    // 색상 설정 (선택 사항)
    public Color normalColor = Color.blue;
    public Color muddyColor = new Color(0.4f, 0.2f, 0f); // 갈색
    public Color driedColor = new Color(0.8f, 0.7f, 0.5f); // 말라있는 흙색

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
            Debug.Log("흙냥이가 물웅덩이를 흙탕물로 바꾸고 말립니다.");
            currentState = PuddleState.Dried;
            UpdatePuddleVisual();
        }
    }

    private void HandleThunderInteraction()
    {
        if (currentState == PuddleState.Normal)
        {
            Debug.Log("번개냥이가 물웅덩이에 닿아 게임 오버!");
            // GameManager.Instance.GameOver(); // 필요 시 게임 오버 로직 실행
        }
        else if (currentState == PuddleState.Dried)
        {
            Debug.Log("번개냥이가 말라 있는 웅덩이를 안전하게 통과합니다.");
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
