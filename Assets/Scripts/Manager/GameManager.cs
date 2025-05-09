using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int playersAtExit = 0;
    private int totalPlayers = 2;

    private bool isGameOver = false;
    private bool isPaused = false;

    void Awake()
    {
        //싱글톤
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        //ESC키 누르면 일시정지 혹은 게임 재개
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }
    public void PauseGame()
    {
        Debug.Log("일시정지");
        isPaused = true;
        Time.timeScale = 0;
        //UI 매니저에서 관리
        //UIManager.Instance.pauseMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        Debug.Log("게임 재개");
        isPaused = false;
        Time.timeScale = 1;
        //UI 매니저에서 관리
        //UIManager.Instance.pauseMenuUI.SetActive(false);
    }

    public void RetryGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        Debug.Log("게임 시작");
        //레벨매니저를 이용한 시작 씬 로드
        //LevelManager.Instance.;
    }
    public void QuitGame()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Time.timeScale = 0;
            //게임오버 UI
            //UIManager.Instance.gameOverUI.SetActive(true);
        }
    }

    //탈출구 도달시
    public void ReachedExit()
    {
        //도착한 플레이어가 두 명 이상일 시
        playersAtExit++;
        if (playersAtExit >= totalPlayers && !isGameOver)
        {
            //레벨 클리어
            isGameOver = true;
            //LevelManager.Instance.levelClearUI.SetActive(true);
        }
    }
}
