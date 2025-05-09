using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void OnClickStartButton(string stageName) // ���������� ���� ���̱� ������, ������ �������� �̸��� ���� ���� �Է�
    {
        // ������ ���������� �̵�
        // SceneManager.LoadScean("���̸�");
    }

    public void OnClickExitButton()
    {
        // ���ξ� �̵�
        // SceneManager.LoadScean("���̸�");
    }

    public void OnClickRetryButton()
    {
        // ���� ���������� �ٽ� ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickPauseButton()
    {
        // �ð� �帧 ����
        Time.timeScale = 0f;
    }

    public void OnClickResumeButton()
    {
        // �ð� �帣��
        Time.timeScale = 1f;
    }
}