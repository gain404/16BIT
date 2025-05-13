using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IntoGameBtn : MonoBehaviour
{
    [SerializeField] private Button ScenChangeButton;

    public void OnClickSceneChange()
    {
        if (GARALoadSceneManager.Instance == null)
        {
            Debug.LogError("LoadSceneManager.Instance�� null�Դϴ�.");
            return;
        }

        Debug.Log("StageSelectScene���� ��ȯ�� �õ��մϴ�.");
        GARALoadSceneManager.Instance.LoadScene(SceneType.StageSelectScene);
    }
}
