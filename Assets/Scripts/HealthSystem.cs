using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;

    [Header("Events")]
    public UnityEvent<float> OnHealthChanged; // porcentaje
    public UnityEvent OnDeath;

    private void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(1f); // 100%
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0f);

        float percent = currentHealth / maxHealth;
        OnHealthChanged?.Invoke(percent);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        float percent = currentHealth / maxHealth;
        OnHealthChanged?.Invoke(percent);
    }

    private void Die()
    {
        OnDeath?.Invoke();
    }
}