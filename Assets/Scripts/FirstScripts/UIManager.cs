using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject initialPanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;

    [Header("Texts")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        ShowInitialUI();
    }

    // ===== UI FLOW =====
    public void ShowInitialUI()
    {
        initialPanel.SetActive(true);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void ShowGameUI()
    {
        initialPanel.SetActive(false);
        gamePanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOverUI()
    {
        initialPanel.SetActive(false);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

 
    public void UpdateHealth(float healthPercent)
    {
        int percent = Mathf.RoundToInt(healthPercent * 100f);
        healthText.text = "Health: " + percent + "%";
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
