using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWater : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (collision.gameObject.CompareTag("Player") && player.playerType == PlayerType.Water)
        {
            Debug.Log("fire");
        }
    }
}
