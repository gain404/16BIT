using UnityEngine;
using System.Collections;

public class stage2Puddle : MonoBehaviour
{
    private enum PuddleState
    {
        Normal,
        Dried
    }

    private PuddleState currentState = PuddleState.Normal;
    private Renderer puddleRenderer;

    public Color driedColor = new Color(0.8f, 0.7f, 0.5f);

    void Start()
    {
        puddleRenderer = GetComponent<Renderer>();
        UpdatePuddleVisual();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("OnCollisionEnter2D");
        if (!other.gameObject.CompareTag("Player")) return;

        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player == null) return;

        switch (player.playerType)
        {
            case PlayerType.Soil:
                Debug.Log("Soil");
                HandleSoilInteraction();
                break;
            case PlayerType.Thunder:
                Debug.Log("Thunder");
                HandleThunderInteraction();
                break;
        }
    }

    private void HandleSoilInteraction()
    {
        if (currentState == PuddleState.Normal)
        {
            Debug.Log("흙냥이가 물웅덩이를 말립니다.");
            currentState = PuddleState.Dried;
            UpdatePuddleVisual();
        }
    }

    private void HandleThunderInteraction()
    {
        if (currentState == PuddleState.Normal)
        {
            Debug.Log("번개냥이가 젖은 물웅덩이에 닿아 게임 오버!");
            GameManager.instance.GameOver();
        }
        else
        {
            Debug.Log("번개냥이가 마른 웅덩이를 안전하게 통과합니다.");
        }
    }

    private void UpdatePuddleVisual()
    {
        if (puddleRenderer != null && currentState == PuddleState.Dried)
        {
            puddleRenderer.material.color = driedColor;
        }
    }
}