using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 _speed = new Vector3(10, 10);
    private Animator _animator;
    private Rigidbody2D _rb;
    public bool _facingRight = true;

    public Bullet _projectilePrefab;
    public Transform _lauchOffset;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(_speed.x * inputX, _speed.y * inputY, 0);

        _animator.SetBool("isWalking", movement.x != 0 || movement.y != 0);


        if ((_facingRight && movement.x < 0) || (!_facingRight && movement.x > 0))
        {
            Flip();
        }

        transform.position += movement * Time.deltaTime;

        //movement *= Time.deltaTime;

        //transform.Translate(movement);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_projectilePrefab, _lauchOffset.position, transform.rotation);
        }
    }

    void Flip()
    {
        _facingRight = !_facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
