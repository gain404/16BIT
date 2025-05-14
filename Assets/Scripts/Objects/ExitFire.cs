using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFire : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (collision.gameObject.CompareTag("Player") && player.playerType == PlayerType.Fire)
        {
            Debug.Log("fire");
        }
    }

    //internal bool IsExitForFirePlayer(PlayerType playerType)
    //{
    //    switch (playerType)
    //    {
    //        case PlayerType.Fire:
    //            return true;
    //        case PlayerType.Water:
    //            return false;
    //        default:
    //            Debug.LogError("Error");
    //            return false;
    //    }
    //}
}
