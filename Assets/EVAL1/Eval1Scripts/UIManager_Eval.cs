using TMPro;
using UnityEngine;

public class UIManager_Eval1 : MonoBehaviour
{
    [Header("Panels")]
    public GameObject initialPanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;

    [Header("Texts")]
    public TMP_Text scoreText;
    public TMP_Text healthText;
    public TMP_Text finalScoreText;

    private ScoreSystem_Eval1 scoreSystem;
    private HealthSystem_Eval1 healthSystem;

    private void Start()
    {
        scoreSystem = FindFirstObjectByType<ScoreSystem_Eval1>();
        healthSystem = FindFirstObjectByType<HealthSystem_Eval1>();

        ShowInitialUI();

        if (healthSystem != null)
        {
            healthSystem.OnHealthChanged += UpdateHealth;
            healthSystem.OnDeath += OnPlayerDeath;
        }

        if (scoreSystem != null)
        {
            scoreSystem.OnScoreChanged += UpdateScore;
        }

        if (GameManager_Eval1.Instance != null)
        {
            GameManager_Eval1.Instance.OnGameStart += ShowGameUI;
            GameManager_Eval1.Instance.OnGameOver += ShowGameOverUI;
        }

        if (scoreSystem != null) UpdateScore(scoreSystem.currentScore);
        if (healthSystem != null) UpdateHealth(healthSystem.currentHealth / healthSystem.maxHealth);
    }

    private void OnDestroy()
    {
        if (healthSystem != null)
        {
            healthSystem.OnHealthChanged -= UpdateHealth;
            healthSystem.OnDeath -= OnPlayerDeath;
        }

        if (scoreSystem != null)
        {
            scoreSystem.OnScoreChanged -= UpdateScore;
        }

        if (GameManager_Eval1.Instance != null)
        {
            GameManager_Eval1.Instance.OnGameStart -= ShowGameUI;
            GameManager_Eval1.Instance.OnGameOver -= ShowGameOverUI;
        }
    }

    public void ShowInitialUI()
    {
        if (initialPanel) initialPanel.SetActive(true);
        if (gamePanel) gamePanel.SetActive(false);
        if (gameOverPanel) gameOverPanel.SetActive(false);
    }

    public void ShowGameUI()
    {
        if (initialPanel) initialPanel.SetActive(false);
        if (gamePanel) gamePanel.SetActive(true);
        if (gameOverPanel) gameOverPanel.SetActive(false);
    }

    public void ShowGameOverUI()
    {
        if (initialPanel) initialPanel.SetActive(false);
        if (gamePanel) gamePanel.SetActive(false);
        if (gameOverPanel) gameOverPanel.SetActive(true);

        if (finalScoreText != null && scoreSystem != null)
            finalScoreText.text = $"Final Score: {scoreSystem.currentScore}";
    }

    public void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = $"Score: {score}";
    }

    public void UpdateHealth(float percent01)
    {
        float percent = Mathf.Clamp01(percent01) * 100f;
        if (healthText != null)
            healthText.text = $"Health: {percent:0}%";
    }

    private void OnPlayerDeath()
    {
        if (GameManager_Eval1.Instance != null)
            GameManager_Eval1.Instance.GameOver();
    }
}
