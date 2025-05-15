using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject stageClearStarPanel;
    public GameObject timeClearStarPanel;
    public GameObject zemClearStarPanel;
    public GameObject gameClearPanel;
    public GameObject gameOverPanel;
    public GameObject gamePausePanel;
  
    public static UIManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
           // DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowStarResult()
    {
        stageClearStarPanel.SetActive(false);
        timeClearStarPanel.SetActive(false);
        zemClearStarPanel.SetActive(false);

        if (LevelManager.Instance.getClearStar)
        {
            stageClearStarPanel.SetActive(true);
        }

        if (LevelManager.Instance.getTimeStar)
        {
            timeClearStarPanel.SetActive(true);
        }

        if (LevelManager.Instance.getZemStar)
        {
            zemClearStarPanel.SetActive(true);
        }

    }
}
