using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float _speed = 10f;

    [Range(1, 10)]
    [SerializeField] private float _lifetime = 1f;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _lifetime);
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        if (_rigidbody)
        {
            _rigidbody.velocity = transform.right * _speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_rigidbody)
        {
            Destroy(gameObject);
        }
    }

}
