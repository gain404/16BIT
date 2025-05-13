using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zem : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("º¸¼® È¹µæ");
            LevelManager.Instance.getZemAmount++;
            Debug.Log("º¸¼® °¹¼ö: " + LevelManager.Instance.getZemAmount);
            Destroy(gameObject);
        }
    }
}
