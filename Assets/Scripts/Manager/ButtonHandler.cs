using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void OnClickStartButton(string stageName) // 스테이지가 여러 개이기 때문에, 선택한 스테이지 이름과 같은 값을 입력
    {
        // 선택한 스테이지씬 이동
        // SceneManager.LoadScean("씬이름");
    }

    public void OnClickExitButton()
    {
        // 메인씬 이동
        // SceneManager.LoadScean("씬이름");
    }

    public void OnClickRetryButton()
    {
        // 현재 스테이지씬 다시 시작
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickPauseButton()
    {
        // 시간 흐름 정지
        Time.timeScale = 0f;
    }

    public void OnClickResumeButton()
    {
        // 시간 흐르게
        Time.timeScale = 1f;
    }
}