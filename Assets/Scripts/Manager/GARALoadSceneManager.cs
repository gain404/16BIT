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

    private void Start()
    {
        // AudioManager.instance가 null이면 씬 전환 후 다시 찾기
        if (AudioManager.instance == null)
        {
            AudioManager foundAudioManager = FindObjectOfType<AudioManager>();
            if (foundAudioManager != null)
            {
                foundAudioManager.Play("Tired");
                Debug.Log("AudioManager Play.");

            }
            else
            {
                Debug.LogWarning("AudioManager not found in scene.");
            }
        }
        else
        {
            AudioManager.instance.Play("Tired");
            Debug.Log("AudioManager Play2.");
        }
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
