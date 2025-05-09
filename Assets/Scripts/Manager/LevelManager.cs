using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private int getZemAmount = 0;
    private int zemAmountMax = 5; // 최대 보석 갯수

    // 총 획득 별 갯수
    private int TotalStarAmount = 0;

    // 싱글톤화 위한 Inatance 선언
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
        onGameFinished = true;
        onGameStarted = false;
        // 게임 종료 시 별 획득 여부에 따라 총 별 갯수 계산
        if (getClearStar)
        {
            TotalStarAmount++;
        }
        if (getTimeStar)
        {
            TotalStarAmount++;
        }
        if (getZemStar)
        {
            TotalStarAmount++;
        }
        // 게임 종료 후 별 갯수 출력
        Debug.Log("총 획득 별 갯수: " + TotalStarAmount);
        GetTotalStarAmount();
    }

    private int GetTotalStarAmount()
    {
        return TotalStarAmount;
    }

    private void IsGetZem()
    {
        getZemAmount++;
        if (getZemAmount >= zemAmountMax) getZemStar = true;
    }

}
