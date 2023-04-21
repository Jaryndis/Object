using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private float currentHealth;
    private float maxHealth;
    private float healthRegenerated;

    public Health(float _maxHealth)
    {
        maxHealth = _maxHealth;
    }

    public Health()
    {

    }

    public Health(float _maxHealth, float _healthRegenerated, float _currentHealth = 100)
    {
        maxHealth = _maxHealth;
        healthRegenerated = _healthRegenerated;
        currentHealth = _currentHealth;
    }

    public void RegenHealth()
    {
        AddHealth(healthRegenerated * Time.deltaTime);
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Max(currentHealth, currentHealth + value);
    }

    public void DeductHealth(float value)
    {
        currentHealth = Mathf.Min(0, currentHealth - value);
    }
}
