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

    private void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Update()
    {
        PushLever();
    }

    //������ ������ ��� event Invoke�ǰ�
    //������ ������ Ű : e
    private void PushLever()
    {
        for (int i = 0;  i < players.Length; i++)
        {
            Vector3 pos = transform.position;
            Vector3 playerPos = players[i].transform.position;

            if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(playerPos, pos) < 0.01f)
            {
                OnLiftChanged?.Invoke(this, true);
            }
        }
    }

}
