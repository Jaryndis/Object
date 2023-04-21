using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    string name;
    float damage;

    public void Shoot()
    {

    }

    public Weapon(string _name, float _damage)
    {
        name = _name;
        damage = _damage;
    }

    public Weapon()
    {
        Debug.Log("General weapon");
    }
}
