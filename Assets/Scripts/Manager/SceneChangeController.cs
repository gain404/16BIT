using UnityEngine;
using UnityEngine.UI;

public class SceneChangeController : MonoBehaviour
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
            GARALoadSceneManager.Instance.ChangeLevel(scene);
            GARALoadSceneManager.Instance.LoadScene(scene);
        }
    }
    public void OpenStage()
    {
        isOpenStage = true;
        lockObject?.SetActive(!isOpenStage);
    }
}
