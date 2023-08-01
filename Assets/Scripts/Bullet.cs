using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private void Update()
    {
        float distance = _speed * Time.deltaTime;
        transform.Translate(Vector2.left * distance, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
            enemy.TakeDamage(_damage);
        
        Destroy(gameObject);
    }
}
