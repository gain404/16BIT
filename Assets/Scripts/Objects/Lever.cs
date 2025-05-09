using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lever : MonoBehaviour
{
    //델리게이트로 부딪혔을 때 이벤트 호출
    public delegate void LiftChange(Lever lever, bool isPressed);
    public event LiftChange OnLiftChanged;

    private void Update()
    {
        PushLever();
    }

    //레버를 눌렀을 경우 event Invoke되게
    //레버를 누르는 키 : e
    private void PushLever()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnLiftChanged?.Invoke(this, true);
        }
    }

}
