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

    public void OpenPanel(GameObject panel) // 코드 사용 예시 : UIManager.instance.OpenPanel(UIManager.instance.gameClearPanel);
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel) // // 코드 사용 예시 : UIManager.instance.ClosePanel(UIManager.instance.gameClearPanel);
    {
        panel.SetActive(false);
    }
}
