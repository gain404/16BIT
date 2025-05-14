using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    private bool isPause = false;
    public void OnClickStartButton(string stageName) // 스테이지가 여러 개이기 때문에, 선택한 스테이지 이름과 같은 값을 입력
    {
        // 선택한 스테이지씬 이동
        // SceneManager.LoadScean("씬이름");
        //GARALoadSceneManager.Instance.LoadScene(SceneType.StageSelectScene);

    }

    public void OnClickInGameButton() // 메인씬에서 stageSelectScene으로 넘어가는 버튼
    {
        SceneManager.LoadScene("StageSelectScene");
    }

    public void OnClickExitButton()
    {
        // 메인씬 이동
        SceneManager.LoadScene("StageSelectScene");
    }

    public void OnClickGameQuitButton()
    {
        // 게임종료
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
       Application.Quit();  
#endif
    }

    public void OnClickRetryButton()
    {
        // 현재 스테이지씬 다시 시작
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickPauseButton()
    {
        Debug.Log("Pause");
        UIManager.instance.gamePausePanel.SetActive(true);
        isPause = true;
        Time.timeScale = 0f;

    }

    public void OnClickResumeButton()
    {
        Debug.Log("Resume");
        UIManager.instance.gamePausePanel.SetActive(false);
        isPause = false;
        Time.timeScale = 1f;
    }
}