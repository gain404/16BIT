using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWater : MonoBehaviour
{
    public Sprite openDoor;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (collision.gameObject.CompareTag("Player") && player.playerType == PlayerType.Water)
        {
            spriteRenderer.sprite = openDoor;
            collision.GetComponent<PlayerController>().enabled = false;
            GameManager.instance.GameClear();
        }
    }
}
