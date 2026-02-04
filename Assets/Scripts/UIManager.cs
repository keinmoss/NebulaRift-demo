using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI sprintText;

    private int health = 100;
    private int score = 10000;
    private int speed = 0;
    private int sprint = 0;

    void Start()
    {
        UpdateUI();
    }

    public void TakeDamage()
    {
        health -= 10;
        score -= 100;
        UpdateUI();
    }

    public void Heal()
    {
        health += 10;
        score += 100;
        UpdateUI();
    }

    public void IncreaseSpeed()
    {
        speed++;
        if (speed % 5 == 0)
            sprint++;

        UpdateUI();
    }

    void UpdateUI()
    {
        healthText.text = "Health: " + health;
        scoreText.text = "Score: " + score;
        speedText.text = "Speed: " + speed;
        sprintText.text = "Sprint: " + sprint;
    }
}