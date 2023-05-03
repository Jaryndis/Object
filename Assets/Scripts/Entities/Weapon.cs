using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    string name;
    float damage;

    float bulletSpeed;

    public Weapon(string _name, float _damage, float _bulletSpeed)
    {
        name = _name;
        damage = _damage;
        bulletSpeed = _bulletSpeed;
    }

    public void Shoot(Bullet _bullet, PlayableObject _player, string _targetTag, float timeToDie = 5)
    {
        Bullet tempBullet = GameObject.Instantiate(_bullet, _player.transform.position, _player.transform.rotation);
        tempBullet.SetBullet(damage, _targetTag, bulletSpeed);

        GameObject.Destroy(tempBullet.gameObject, timeToDie);
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

    public float GetDamage()
    {
        return damage;
    }
}
