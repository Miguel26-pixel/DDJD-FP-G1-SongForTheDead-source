using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float _speed = 100f;

    [Range(1, 10)]
    [SerializeField] private float _lifetime = 1f;

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
        Debug.Log("ola2");
    }

    public float getSpeed()
    {
        return _speed;
    }

}
