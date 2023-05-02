using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float speed;

    private string targetTag;

    public void SetBullet(float _damage, string _targetTag, float _speed = 10)
    {
        damage = _damage;
        speed = _speed;
        targetTag = _targetTag;
    }

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

            GameManager.GetInstance().scoreManager.IncrementScore();

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if(!collision.gameObject.CompareTag(targetTag))
        {
            return;
        }

        IDamageable damageable = collision.GetComponent<IDamageable>();
        Damage(damageable);

        Debug.Log("Other obejct's name =" + collision.gameObject.name);
    }
}
