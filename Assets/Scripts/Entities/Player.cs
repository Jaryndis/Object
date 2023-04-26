using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayableObject
{
    
    [SerializeField] private float speed;
    [SerializeField] Camera cam;

    private Rigidbody2D playerRB;

    private void Start()
    {
        health = new Health(100, 0.5f, 100);
        playerRB = GetComponent<Rigidbody2D>();

        testScore++;
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
    }

    public override void Die()
    {
        Debug.Log("Player died");
    }

    public override void Attack(float interval)
    {
        
    }

    public override void GetDamage(float damage)
    {
        
    }
}
