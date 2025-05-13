using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // 게임 시작/종료 여부 판정
    private bool onGameStarted;
    private bool onGameFinished;

    // 플레이어 사망/오브젝트 충돌 판정
    PlayerController playerController;

    // 게임 진행 시간 및 시간 관련 별 획득 여부
    private float gameTime;
    private float getStartime;

    // 별 획득 여부
    internal bool getClearStar = false;
    internal bool getTimeStar = false;
    internal bool getZemStar = false;

    // 플레이어가 획득한 보석 갯수
    internal int getZemAmount = 0;
    internal int zemAmountMax = 5; // 최대 보석 갯수

    // 총 획득 별 갯수
    private int TotalStarAmount = 0;
    private int HighTotalStarAmount; // 최고 별 갯수

    // 레벨별 클리어 여부 변수
    public Stage stage;
    internal bool isLevel1Clear = false; // 레벨 클리어 여부
    internal bool isLevel2Clear = false; // 레벨 클리어 여부
    internal bool isLevel3Clear = false; // 레벨 클리어 여부

    // 싱글톤화 위한 Inatance 선언
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
                Debug.Log("스테이지 1 클리어!");
                break;

            case Stage.Stage2:
                isLevel2Clear = true;
                Debug.Log("스테이지 2 클리어!");
                break;

            case Stage.Stage3:
                isLevel3Clear = true;
                Debug.Log("스테이지 3 클리어!");
                break;
        }

        onGameFinished = true;
        onGameStarted = false;

        if (getClearStar) TotalStarAmount++;
        if (getTimeStar) TotalStarAmount++;
        if (getZemStar) TotalStarAmount++;

        Debug.Log("총 획득 별 갯수: " + TotalStarAmount);

        GetTotalStarAmount(currentStage); // 스테이지별 최고 점수 갱신
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
            _ => throw new System.Exception("알 수 없는 씬 이름: " + sceneName)
        };
    }
}
