using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : PlayableObject
{
    
    [SerializeField] private float speed;
    [SerializeField] Camera cam;

    [SerializeField] float weaponDamage = 1;
    [SerializeField] float bulletSpeed = 10;
    [SerializeField] Bullet bulletPrefab;

    private Rigidbody2D playerRB;

    //public Action<float> OnHealthUpdate;

    private void Awake()
    {
        health = new Health(100, 0.5f, 50);
        playerRB = GetComponent<Rigidbody2D>();

        weapon = new Weapon("Player Weapon", weaponDamage, bulletSpeed);

        //OnHealthUpdate?.Invoke(health.GetHealth());
    }

    public override void Move(Vector2 direction, Vector2 target)
    {
        playerRB.velocity = direction * speed * Time.deltaTime;

        var playerScreenPos = cam.WorldToScreenPoint(transform.position);
        target.x -= playerScreenPos.x;
        target.y -= playerScreenPos.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public override void Shoot()
    {
        Debug.Log("Shooting bullets toward direction");
        weapon.Shoot(bulletPrefab, this, "Enemy");
    }

    public override void Die()
    {
        Debug.Log("Player died");
        Destroy(gameObject);
    }

    public override void Attack(float interval)
    {
        
    }

    public override void GetDamage(float damage)
    {
        Debug.Log("Player damaged!" + damage);
        health.DeductHealth(damage);

        //OnHealthUpdate?.Invoke(health.GetHealth());

        if(health.GetHealth() <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        health.RegenHealth();
    }
}
