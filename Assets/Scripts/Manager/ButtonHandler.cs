using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void OnClickSceneChangeButton(string stageName) // ���������� ���� ���̱� ������, ������ �������� �̸��� ���� ���� �Է�
    {
        // ������ ���������� �̵�
        // SceneManager.LoadScean("���̸�");
        //GARALoadSceneManager.Instance.LoadScene(SceneType.StageSelectScene);

    }

    public void OnClickInGameButton() // ���ξ����� stageSelectScene���� �Ѿ�� ��ư
    {
        SceneManager.LoadScene("StageSelectScene");
    }

    public void OnClickExitButton()
    {
        // ���ξ� �̵�
        // SceneManager.LoadScean("���̸�");
    }

    public void OnClickGameQuitButton()
    {
        // ��������
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
       Application.Quit();  
#endif
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