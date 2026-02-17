using UnityEngine;

public class CubeDamage_Eval1 : MonoBehaviour
{
    public float damageAmount = 15f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        var health = FindFirstObjectByType<HealthSystem_Eval1>();
        if (health != null)
            health.TakeDamage(damageAmount);
    }
}