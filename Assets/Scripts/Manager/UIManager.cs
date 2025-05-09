using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject stageClearStarPanel;
    public GameObject stageUnclearStarPanel;
    public GameObject timeClearStarPanel;
    public GameObject timeUnclearStarPanel;
    public GameObject zemClearStarPanel;
    public GameObject zemUnclearStarPanel;
    public GameObject gameClearPanel;
    public GameObject gameOverPanel;
    public GameObject gamePausePanel;
    public GameObject gameSettingsPanel;
    public GameObject inGamePanel;

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

    public void ShowStarResult()
    {
        // 모든 별 초기화
        stageClearStarPanel.SetActive(false);
        stageUnclearStarPanel.SetActive(false);
        timeClearStarPanel.SetActive(false);
        timeUnclearStarPanel.SetActive(false);
        zemClearStarPanel.SetActive(false);
        zemUnclearStarPanel.SetActive(false);

        if (LevelManager.Instance.getClearStar)
        {
            stageClearStarPanel.SetActive(true);
        }
        else
        {
            stageUnclearStarPanel.SetActive(true);
        }

        if (LevelManager.Instance.getTimeStar)
        {
            timeClearStarPanel.SetActive(true);
        }
        else
        {
            timeUnclearStarPanel.SetActive(true);
        }

        if (LevelManager.Instance.getZemStar)
        {
            zemClearStarPanel.SetActive(true);
        }
        else
        {
            zemUnclearStarPanel.SetActive(true);
        }
    }
}
