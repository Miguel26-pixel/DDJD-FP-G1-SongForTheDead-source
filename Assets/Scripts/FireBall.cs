using UnityEngine;

public class FireBall : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float _speed = 10f;

    [SerializeField] private float _damage = 1f;

    [SerializeField] private Player playerTarget;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        // Destroy(gameObject, _lifetime);
        playerTarget = GameObject.FindWithTag("Player")?.GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_rigidbody)
        {
            if (collision.gameObject.CompareTag("Player")) {
                playerTarget.TakeDamage(_damage);
            }
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
