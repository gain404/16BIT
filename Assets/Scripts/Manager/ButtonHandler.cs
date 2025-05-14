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
        // �ð� �帧 ����

        if (!isPause)
        {
            Time.timeScale = 0f;
            isPause = true;
        }
        else
        {
            
            Time.timeScale = 1f;
            isPause = false;
        }
    }

    public void OnClickResumeButton()
    {
        // �ð� �帣��
        Time.timeScale = 1f;
    }
}