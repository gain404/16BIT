using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public delegate void SwitchEventHandler(bool isPressed);
    public event SwitchEventHandler OnSwitchStateChanged;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Switch OnTriggerEnter");
            OnSwitchStateChanged?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Switch OnTriggerExit");
            OnSwitchStateChanged?.Invoke(false);
        }
    }

}