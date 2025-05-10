using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lever : MonoBehaviour
{
    //델리게이트로 부딪혔을 때 이벤트 호출
    public delegate void LiftChange(Lever lever, bool isPressed);
    public event LiftChange OnLiftChanged;
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
        PushLever();
    }

    //레버를 눌렀을 경우 event Invoke되게
    //레버를 누르는 키 : e
    private void PushLever()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPush)
        {
            OnLiftChanged?.Invoke(this, true);
        }
    }

}
