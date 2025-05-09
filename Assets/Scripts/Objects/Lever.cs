using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lever : MonoBehaviour
{
    //��������Ʈ�� �ε����� �� �̺�Ʈ ȣ��
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

    //������ ������ ��� event Invoke�ǰ�
    //������ ������ Ű : e
    private void PushLever()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPush)
        {
            OnLiftChanged?.Invoke(this, true);
        }
    }

}
