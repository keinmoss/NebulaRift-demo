using System;
using UnityEngine;

public class HealthSystem_Eval1 : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    public event Action<float> OnHealthChanged; // 0..1
    public event Action OnDeath;

    private bool dead = false;

    private void Start()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        RaiseHealthChanged();
    }

    public void TakeDamage(float amount)
    {
        if (dead) return;

        currentHealth -= Mathf.Abs(amount);
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        RaiseHealthChanged();

        if (currentHealth <= 0f)
        {
            dead = true;
            OnDeath?.Invoke();
        }
    }

    public void Heal(float amount)
    {
        if (dead) return;

        currentHealth += Mathf.Abs(amount);
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        RaiseHealthChanged();
    }

    private void RaiseHealthChanged()
    {
        float percent = (maxHealth <= 0f) ? 0f : currentHealth / maxHealth;
        OnHealthChanged?.Invoke(percent);
    }
}