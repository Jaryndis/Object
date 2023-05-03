using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health
{
    private float currentHealth;
    private float maxHealth;
    private float healthRegenerated;

    public Action<float> OnHealthUpdate;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public float GetHealth()
    {
        return currentHealth;
    }

    public void SetHealth(float value)
    {
        if(value > maxHealth || value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"Valid range for health is between 0 and {maxHealth}");
        }
        currentHealth = value;
    }
    public Health(float _maxHealth)
    {
        maxHealth = _maxHealth;
    }

    public Health()
    {

    }

    public Health(float _maxHealth, float _healthRegenerated, float _currentHealth = 100)
    {
        currentHealth = _currentHealth;
        maxHealth = _maxHealth;
        healthRegenerated = _healthRegenerated;
        
        OnHealthUpdate?.Invoke(currentHealth);
    }

    public void RegenHealth()
    {
        AddHealth(healthRegenerated * Time.deltaTime);
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + value);
        OnHealthUpdate?.Invoke(currentHealth);
    }

    public void DeductHealth(float value)
    {
        currentHealth = Mathf.Max(0, currentHealth - value);
        OnHealthUpdate?.Invoke(currentHealth);
    }
}
