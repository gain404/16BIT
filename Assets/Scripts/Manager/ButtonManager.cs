using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject startBtn;
    public GameObject exitBtn;
    public GameObject retryBtn;
    public GameObject pauseBtn;
    public GameObject resumeBtn;

    public enum ButtonType
    {
        Start,
        Exit,
        Retry,
        Pause,
        Resume
    }
}