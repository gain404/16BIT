using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lever : MonoBehaviour
{
    //��������Ʈ�� �ε����� �� �̺�Ʈ ȣ��
    public delegate void LiftChange(Lever lever, bool isPressed);
    public event LiftChange OnLiftChanged;

    private void Update()
    {
        PushLever();
    }

    //������ ������ ��� event Invoke�ǰ�
    //������ ������ Ű : e
    private void PushLever()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnLiftChanged?.Invoke(this, true);
        }
    }

}
