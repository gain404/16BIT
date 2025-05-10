using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public delegate void SwitchEventHandler(bool isPressed);
    public event SwitchEventHandler OnSwitchStateChanged;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Switch OnTriggerEnter");
            OnSwitchStateChanged?.Invoke(true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Switch OnTriggerExit");
            OnSwitchStateChanged?.Invoke(false);
        }
    }

}