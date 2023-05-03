using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup, IDamageable
{
    [SerializeField] float healthMin;
    [SerializeField] float healthMax;

    public override void OnPicked()
    {
        base.OnPicked();

        //Increase health here.
        float health = Random.Range(healthMin, healthMax);

        var player = GameManager.GetInstance().GetPlayer();

        player.health.AddHealth(health);

        Debug.Log($"Added {health} health to the player");
    }

    public void GetDamage(float damage)
    {
        OnPicked();
    }
}
