using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : PlayableObject
{
    //private float speed;

    private EnemyType enemyType;

    protected Transform target;
    [SerializeField] protected float speed;

    protected virtual void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        if(target != null)
        {
            Move(target.position);
        }
        else
        {
            Move(speed);
        }
    }
    public override void Move(Vector2 direction, Vector2 target)
    {
        Debug.Log("Enemy moving towards the direction");
    }

    public override void Move(float speed)
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public override void Move(Vector2 direction)
    {
        direction.x -= transform.position.x;
        direction.y -= transform.position.y;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public override void Shoot()
    {
        Debug.Log("Shooting bullets towards direction");
    }

    public override void Die()
    {
        Debug.Log("Player died");
    }

    public override void Attack(float interval)
    {
        Debug.Log("Enemy attacking...");
    }

    public void SetEnemyType(EnemyType enemyType)
    {
        this.enemyType = enemyType;
    }

    public override void GetDamage(float damage)
    {
       
    }
}
