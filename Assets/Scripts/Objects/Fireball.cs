using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = GetComponent<PlayerController>();
        if (player != null && player.playerType == PlayerType.Water)
        {
            Debug.Log("Damaged");
        }
    }
}
