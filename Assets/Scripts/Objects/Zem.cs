using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zem : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("���� ȹ��");
            LevelManager.Instance.getZemAmount++;
            Debug.Log("���� ����: " + LevelManager.Instance.getZemAmount);
            Destroy(gameObject);
        }
    }
}
