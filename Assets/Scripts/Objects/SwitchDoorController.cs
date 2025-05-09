using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoorController : MonoBehaviour
{
    // 스위치들을 할당할 수 있도록 public
    public List<Switch> controllingSwitches;

    private Dictionary<Switch, bool> switchStates = new Dictionary<Switch, bool>();

    private void Start()
    {
        foreach (var sw in controllingSwitches)
        {
            switchStates[sw] = false;
            sw.OnSwitchStateChanged += (isPressed) => {
                switchStates[sw] = isPressed;
                UpdateDoorState();
            };
        }
    }

    private void UpdateDoorState()
    {
        bool anyPressed = false;
        foreach (var state in switchStates.Values)
        {
            if (state)
            {
                anyPressed = true;
                break;
            }
        }
        gameObject.SetActive(!anyPressed); // 하나라도 눌리면 문 열기
    }
}
