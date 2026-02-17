using System;
using UnityEngine;

public class ScoreSystem_Eval1 : MonoBehaviour
{
    public int currentScore { get; private set; } = 0;

    public event Action<int> OnScoreChanged;

    public void AddScore(int amount)
    {
        currentScore += amount;
        if (currentScore < 0) currentScore = 0;

        OnScoreChanged?.Invoke(currentScore);
    }
}