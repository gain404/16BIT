using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum PuddleType
{
    Fire,
    Water,
}
public class PuddleHandler : MonoBehaviour
{
    [SerializeField] private PuddleType puddleType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (collision.CompareTag("Player") && CheckingPuddleType(player.playerType))
        {
            GameManager.instance.GameOver();
        }
    }

    private bool CheckingPuddleType(PlayerType playerType)
    {
        switch (puddleType)
        {
            case PuddleType.Fire:
                return playerType != PlayerType.Fire;
            case PuddleType.Water:
                return playerType != PlayerType.Water;

            default:
                Debug.LogError("설정되지 않음");
                return false;
        }
    }
}
