using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // ���� ����/���� ���� ����
    private bool onGameStarted;
    private bool onGameFinished;

    // �÷��̾� ���/������Ʈ �浹 ����
    PlayerController playerController;

    // ���� ���� �ð� �� �ð� ���� �� ȹ�� ����
    private float gameTime;
    private float getStartime;

    // �� ȹ�� ����
    internal bool getClearStar = false;
    internal bool getTimeStar = false;
    internal bool getZemStar = false;

    // �÷��̾ ȹ���� ���� ����
    internal int getZemAmount = 0;
    internal int zemAmountMax = 5; // �ִ� ���� ����

    // �� ȹ�� �� ����
    private int TotalStarAmount = 0;
    private int HighTotalStarAmount; // �ְ� �� ����

    // ������ Ŭ���� ���� ����
    public Stage stage;
    internal bool isLevel1Clear = false; // ���� Ŭ���� ����
    internal bool isLevel2Clear = false; // ���� Ŭ���� ����
    internal bool isLevel3Clear = false; // ���� Ŭ���� ����

    // �̱���ȭ ���� Inatance ����
    public static LevelManager Instance;

    private void Awake()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (Instance == null)
        {
            Instance = this;
            //  DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        onGameStarted = true;
        OnGameFinished();
    }

    private void Update()
    {
        OnGameStarted();
    }


    private void OnGameStarted()
    {
        if (onGameStarted && !onGameFinished)
        {
            gameTime += Time.deltaTime;
        }

        if (gameTime <= getStartime)
        {
            getTimeStar = true;
        }
    }

    private void OnGameFinished()
    {
        Stage currentStage = GetCurrentStage();

        switch (currentStage)
        {
            case Stage.Stage1:
                isLevel1Clear = true;
                Debug.Log("�������� 1 Ŭ����!");
                break;

            case Stage.Stage2:
                isLevel2Clear = true;
                Debug.Log("�������� 2 Ŭ����!");
                break;

            case Stage.Stage3:
                isLevel3Clear = true;
                Debug.Log("�������� 3 Ŭ����!");
                break;
        }

        onGameFinished = true;
        onGameStarted = false;

        if (getClearStar) TotalStarAmount++;
        if (getTimeStar) TotalStarAmount++;
        if (getZemStar) TotalStarAmount++;

        Debug.Log("�� ȹ�� �� ����: " + TotalStarAmount);

        GetTotalStarAmount(currentStage); // ���������� �ְ� ���� ����
    }

    private int GetTotalStarAmount(Stage stage)
    {
        string key = $"HighTotalStar_{stage}";
        int savedHigh = PlayerPrefs.GetInt(key, 0);

        if (savedHigh < TotalStarAmount)
        {
            SetHighTotalStar(stage);
        }


        return TotalStarAmount;
    }
    private void SetHighTotalStar(Stage stage)
    {
        string key = $"HighTotalStar_{stage}";
        PlayerPrefs.SetInt(key, TotalStarAmount);
        PlayerPrefs.Save();
    }


    private void IsGetZem()
    {
        getZemAmount++;
        if (getZemAmount >= zemAmountMax) getZemStar = true;
    }

    public enum Stage
    {
        Stage1,
        Stage2,
        Stage3
    }

    private Stage GetCurrentStage()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        return sceneName switch
        {
            "Stage1" => Stage.Stage1,
            "Stage2" => Stage.Stage2,
            "Stage3" => Stage.Stage3,
            _ => throw new System.Exception("�� �� ���� �� �̸�: " + sceneName)
        };
    }
}
