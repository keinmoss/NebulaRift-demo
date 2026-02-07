using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game State")]
    public bool isGamePaused;
    public bool isGameOver;

    [Header("Events")]
    public UnityEvent OnGameStart;
    public UnityEvent OnGamePause;
    public UnityEvent OnGameOver;

    private void Awake()
    {
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

    public void StartGame()
    {
        isGamePaused = false;
        isGameOver = false;
        Time.timeScale = 1f;
        OnGameStart?.Invoke();
    }

    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f;
        OnGamePause?.Invoke();
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        OnGameOver?.Invoke();
    }
}