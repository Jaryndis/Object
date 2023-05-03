using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] float attackRange;
    [SerializeField] float attackTime = 0;

    float timer = 0;
    float setSpeed = 0;

    protected override void Start()
    {
        base.Start();
        health = new Health(1, 0, 1);
        setSpeed = speed;
    }

    protected override void Update()
    {
        base.Update();

        if (target == null)
        {
            return;
        }

        if(Vector2.Distance(transform.position, target.position) < attackRange)
        {
            speed = 0;
            Attack(attackTime);
        }
        else
        {
            speed = setSpeed;
        }
    }

    /*public override void GetDamage(float damage)
    {
        health.DeductHealth(damage);
    }*/

    public override void Attack(float interval)
    {
        if(timer <= interval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            target.GetComponent<IDamageable>().GetDamage(weapon.GetDamage());
        }
    }

    public void SetMeleeEnemy(float _attackRange, float _attackTime)
    {
        attackRange = _attackRange;
        attackTime = _attackTime;
    }
}
