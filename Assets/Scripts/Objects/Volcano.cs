using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano : MonoBehaviour
{
    public float volcanoForce = 5f; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null && player.playerType == PlayerType.Fire)
        {
            player.jumpForce += volcanoForce;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null && player.playerType == PlayerType.Fire)
        {
            player.jumpForce -= volcanoForce;
        }
    }
}
