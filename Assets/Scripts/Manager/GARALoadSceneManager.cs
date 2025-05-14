using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum SceneType
{
    MainScene,
    StageSelectScene,
    Stage1,
    Stage2,
    Stage3
}
public class GARALoadSceneManager : MonoBehaviour
{
    public static GARALoadSceneManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void LoadScene(SceneType _scene)
    {
        // _scene�� ���� �� �̸��� ����
        string sceneName = _scene.ToString();
        Debug.Log($"Loading scene: {sceneName}");
        SceneManager.LoadScene(sceneName);
    }
}
