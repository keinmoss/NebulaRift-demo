using UnityEngine;

public class CubeScore_Eval1 : MonoBehaviour
{
    public int scoreAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        var score = FindFirstObjectByType<ScoreSystem_Eval1>();
        if (score != null)
            score.AddScore(scoreAmount);
    }
}