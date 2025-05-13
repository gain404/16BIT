using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityLever : MonoBehaviour
{
    private GameObject[] players;

    private bool isPush = false;

    private void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPush = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPush = false;
        }
    }

    private void Update()
    {
        PushGravityLever();
    }

    //������ ������ ��� event Invoke�ǰ�
    //������ ������ Ű : e
    private void PushGravityLever()
    {
        Debug.Log("isPush : " + isPush);
        if (Input.GetKeyDown(KeyCode.E) && isPush)
        {
            Debug.Log("isPush2 : " + isPush);
            if (GravityHandler.instance.gravityReversed == false) GravityHandler.instance.gravityReversed = true;
            else GravityHandler.instance.gravityReversed = false;
        }
    }
}
