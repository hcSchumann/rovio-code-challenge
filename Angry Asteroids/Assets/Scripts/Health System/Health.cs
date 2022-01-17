using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public HealthBarBehaviour HealthBarBehaviour;
    public Action OnDie;
    public int MaxHealth = 100;
    private int _currentHealth = 100;

    private void Start()
    {
        RestoreHealth();
    }
    public void DecreaseHealth(int amount)
    {
        _currentHealth -= amount;
        UpdateHealthBar();
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Die();
        }
    }

    public void RestoreHealth()
    {
        _currentHealth = MaxHealth;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        HealthBarBehaviour.SetHealthBarFillValue(_currentHealth / (float)MaxHealth);
    }

    private void Die()
    {
        OnDie?.Invoke();
        Destroy(gameObject);
    }
}
