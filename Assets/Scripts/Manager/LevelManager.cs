using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private int getZemAmount = 0;
    private int zemAmountMax = 5; // �ִ� ���� ����

    // �� ȹ�� �� ����
    private int TotalStarAmount = 0;

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
        // ���� ���� �� �� ȹ�� ���ο� ���� �� �� ���� ���
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
        // ���� ���� �� �� ���� ���
        Debug.Log("�� ȹ�� �� ����: " + TotalStarAmount);
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
