using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectUI : MonoBehaviour
{
    [Header("스테이지 UI 목록")]
    [SerializeField] private GameObject[] stageUIs;

    [Header("버튼")]
    [SerializeField] private Button nextButton;
    [SerializeField] private Button prevButton;

    [SerializeField] private Button ScenChangeButton;

    private int currentStageIndex = 0;

    private void Start()
    {
        UpdateStageUI();
    }

    public void OnClickNextStageButton()
    {
        if (currentStageIndex < stageUIs.Length - 1)
        {
            currentStageIndex++;
            UpdateStageUI();
        }
    }

    public void OnClickPrevStageButton()
    {
        if (currentStageIndex > 0)
        {
            currentStageIndex--;
            UpdateStageUI();
        }
    }

    public void UpdateStageUI()
    {
        for (int i = 0; i < stageUIs.Length; i++)
        {
            stageUIs[i].SetActive(i == currentStageIndex);
        }

        UpdateButtonInteractable(currentStageIndex, stageUIs.Length);
    }

    public void UpdateButtonInteractable(int currentIndex, int maxCount)
    {
        prevButton.interactable = currentIndex > 0;
        nextButton.interactable = currentIndex < maxCount - 1;
    }

    public void OnClickSceneChange()
    {
        if (GARALoadSceneManager.Instance == null)
        {
            Debug.LogError("LoadSceneManager.Instance가 null입니다.");
            return;
        }

        Debug.Log("StageSelectScene으로 전환을 시도합니다.");
        GARALoadSceneManager.Instance.LoadScene(SceneType.StageSelectScene);
    }
}
