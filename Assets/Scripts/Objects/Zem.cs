using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LevelManager.Instance.getZemAmount++;
            Debug.Log("Á¡¼ö: " + LevelManager.Instance.getZemAmount);
            Destroy(this.gameObject);
        }
    }
}
