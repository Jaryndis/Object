using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float speed;

    private void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void Damage(IDamageable damageable)
    {
        if(damageable != null)
        {
            damageable.GetDamage(damage);
            Debug.Log("Damage something");
            LevelLoader.SCORE++;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Other obejct's name =" + collision.gameObject.name);

        IDamageable damageable = collision.GetComponent<IDamageable>();
        Damage(damageable);
    }
}
