using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{

    private bool isPause = false;
    public void OnClickStartButton(string stageName) // ���������� ���� ���̱� ������, ������ �������� �̸��� ���� ���� �Է�
    {
        // ������ ���������� �̵�
        // SceneManager.LoadScean("���̸�");
    }

    public void OnClickExitButton()
    {
        // ���ξ� �̵�
        SceneManager.LoadScene("StageSelectScene");
    }

    public void OnClickRetryButton()
    {
        // ���� ���������� �ٽ� ����
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