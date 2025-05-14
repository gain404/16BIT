using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public float gameTime;
    public float getStartime;
    public TextMeshProUGUI timeText;

    // �� ȹ�� ����
    internal bool getClearStar = false;
    internal bool getTimeStar = false;
    internal bool getZemStar = false;

    // �÷��̾ ȹ���� ���� ����
    public int getZemAmount = 0;
    public int zemAmountMax; // �ִ� ���� ����

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

        Stage currentStage = GetCurrentStage();

        switch (currentStage)
        {
            case Stage.Stage1:
                AudioManager.instance.Play("Picnic");
                break;

            case Stage.Stage2:
                AudioManager.instance.Play("Premonition");
                break;

            case Stage.Stage3:
                AudioManager.instance.Play("Space");
                break;
        }
    }

    private void Update()
    {
        OnGameStarted();
    }


    private void OnGameStarted()
    {
        
        if (onGameStarted && !onGameFinished)
        {
            Debug.Log("���� ����!");
            gameTime += Time.deltaTime;
            timeText.text = gameTime.ToString("F1");
            Debug.Log("�ð� �帣��");
        }
    }

    internal void OnGameFinished()
    {
        Stage currentStage = GetCurrentStage();

        if (gameTime <= getStartime) getTimeStar = true;
        if (getZemAmount == zemAmountMax) getZemStar = true;

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

        getClearStar = true;
        onGameFinished = true;
        onGameStarted = false;

        if (getClearStar)
        {
            TotalStarAmount++;
        }
        if (getTimeStar)
        {
            TotalStarAmount++;
            UIManager.instance.timeClearStarPanel.SetActive(false);

        }
        if (getZemStar)
        {
            TotalStarAmount++;
            UIManager.instance.zemClearStarPanel.SetActive(false);
        }

        Debug.Log("��Ÿ(Ŭ����): " + getClearStar);
        Debug.Log("��Ÿ(�ð�): " + getTimeStar);
        Debug.Log("��Ÿ(����): " + getZemStar);
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
