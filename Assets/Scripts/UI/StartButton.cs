using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] SceneType scene;
    [SerializeField] Button sceneBtn;
    [SerializeField] GameObject lockObject;

    [SerializeField] bool isOpenStage;
    void Start()
    {
        sceneBtn.onClick.RemoveAllListeners();
        sceneBtn.onClick.AddListener(() => OnClickStartBtn());

    }
    public void OnClickStartBtn()
    {
        if (isOpenStage)
        {
            GARALoadSceneManager.Instance.LoadScene(scene);
            //LevelManager.Instance.OnClickStart();
        }
    }
    public void OpenStage()
    {
        isOpenStage = true;
        lockObject?.SetActive(!isOpenStage);
    }
}
