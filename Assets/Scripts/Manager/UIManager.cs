using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameClearPanel;
    public GameObject gameOverPanel;
    public GameObject gamePausePanel;
    public GameObject gameSettingsPanel;

    public static UIManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void OpenPanel(GameObject panel) // �ڵ� ��� ���� : UIManager.instance.OpenPanel(UIManager.instance.gameClearPanel);
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel) // // �ڵ� ��� ���� : UIManager.instance.ClosePanel(UIManager.instance.gameClearPanel);
    {
        panel.SetActive(false);
    }
}
