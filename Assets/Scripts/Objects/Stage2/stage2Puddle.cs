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
            Debug.Log("����̰� �������̸� �����ϴ�.");
            currentState = PuddleState.Dried;
            UpdatePuddleVisual();
        }
    }

    private void HandleThunderInteraction()
    {
        if (currentState == PuddleState.Normal)
        {
            Debug.Log("�������̰� ���� �������̿� ��� ���� ����!");
            GameManager.instance.GameOver();
        }
        else
        {
            Debug.Log("�������̰� ���� �����̸� �����ϰ� ����մϴ�.");
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