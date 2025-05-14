using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum SceneType
{
    Stage1,
    Stage2,
    Stage3
}
public class GARALoadSceneManager : MonoBehaviour
{
    public static GARALoadSceneManager Instance { get; private set; }

    public SceneType UnlockedStage = SceneType.Stage1;

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
        // _scene에 따라 씬 이름을 매핑
        string sceneName = _scene.ToString();
        Debug.Log($"Loading scene: {sceneName}");
        SceneManager.LoadScene(sceneName);
    }

    public void LevelUp()
    {
        UnlockedStage += 1;
    }

    public void ChangeLevel(SceneType _stage)
    {
        UnlockedStage = _stage;
    }
}
