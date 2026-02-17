using UnityEngine;
using UnityEngine.Events;

public class ScoreSystem : MonoBehaviour
{
    [Header("Score Settings")]
    [SerializeField] private int currentScore = 0;

    [Header("Events")]
    public UnityEvent<int> OnScoreChanged;

    private void Start()
    {
        OnScoreChanged?.Invoke(currentScore);
    }

    public void AddScore(int points)
    {
        currentScore += points;
        OnScoreChanged?.Invoke(currentScore);
    }

    public int GetScore()
    {
        return currentScore;
    }
}