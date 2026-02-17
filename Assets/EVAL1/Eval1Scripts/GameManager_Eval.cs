using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Eval1 : MonoBehaviour
{
    public static GameManager_Eval1 Instance { get; private set; }

    public bool isGamePaused { get; private set; }
    public bool isGameOver { get; private set; }

    public event Action OnGameStart;
    public event Action OnGameOver;
    public event Action<bool> OnPauseChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
    }

    private void Start()
    {
        isGamePaused = false;
        isGameOver = false;
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        if (isGameOver) return;

        isGamePaused = false;
        Time.timeScale = 1f;

        OnGameStart?.Invoke();
    }

    public void PauseGame()
    {
        if (isGameOver) return;

        isGamePaused = !isGamePaused;
        Time.timeScale = isGamePaused ? 0f : 1f;

        OnPauseChanged?.Invoke(isGamePaused);
    }


    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        isGamePaused = false;
        Time.timeScale = 1f;

        OnGameOver?.Invoke();
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        isGameOver = false;
        isGamePaused = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}