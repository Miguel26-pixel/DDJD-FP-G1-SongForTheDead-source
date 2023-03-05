using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float _speed = 100f;

    [Range(1, 10)]
    [SerializeField] private float _lifetime = 1f;

    [SerializeField] private float _damage = 1f;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_rigidbody)
        {
            Destroy(gameObject);
        }
    }

    public float getSpeed()
    {
        return _speed;
    }

    public void setDamage(float damage)
    { 
        _damage = damage;
    }

    public float getDamage()
    { 
        return _damage;
    }

}
