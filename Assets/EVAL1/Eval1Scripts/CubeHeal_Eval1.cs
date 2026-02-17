using UnityEngine;

public class CubeHeal_Eval1 : MonoBehaviour
{
    public float healAmount = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        var health = FindFirstObjectByType<HealthSystem_Eval1>();
        if (health != null)
            health.Heal(healAmount);
    }
}