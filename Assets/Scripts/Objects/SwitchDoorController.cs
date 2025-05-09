using System.Collections.Generic;
using UnityEngine;

public class SwitchDoorController : MonoBehaviour
{

    [SerializeField] private List<Switch> controllingSwitches;
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
        gameObject.SetActive(!anyPressed); // 하나라도 스위치 밟히면 문이 열림
    }
}
