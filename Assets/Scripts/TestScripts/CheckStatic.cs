using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStatic : PlayableObject
{
    static int number;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNumbers()
    {
        number++;
        Debug.Log($"New number = {number}");
    }

    public override void Move(Vector2 direction, Vector2 target)
    {
        throw new System.NotImplementedException();
    }

    public override void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public override void Attack(float interval)
    {
        throw new System.NotImplementedException();
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void GetDamage(float damage)
    {
        throw new System.NotImplementedException();
    }
}
