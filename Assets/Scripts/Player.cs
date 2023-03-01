using UnityEngine;

public class Player : MonoBehaviour
{

    public Camera cam1;
    public Camera cam2;
    // Moving
    private Animator _animator;
    private Rigidbody2D _rb;

    public Vector3 _speed = new Vector3(10, 10);
    private bool _facingRight = true;

    // Attacking
    [SerializeField]
    private Bullet _projectilePrefab;
    [SerializeField]
    private Transform _lauchOffset;
    private Vector3 _myScreenPos;
    private float _shootingSpeed;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _shootingSpeed = _projectilePrefab.getSpeed();
    }

    void Update()
    {
        if(cam1.enabled){
            _myScreenPos = cam1.WorldToScreenPoint(this.transform.position);
        } else {
            _myScreenPos = cam2.WorldToScreenPoint(this.transform.position);
        }

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(_speed.x * inputX, _speed.y * inputY, 0);

        Vector3 shootingDirection = (Input.mousePosition - _myScreenPos).normalized;

        _animator.SetBool("isWalking", movement.x != 0 || movement.y != 0);


        if ((_facingRight && movement.x < 0) || (!_facingRight && movement.x > 0))
        {
            Flip();
        }

        transform.position += movement * Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            Bullet bullet = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootingDirection.x, shootingDirection.y) * _shootingSpeed;
        }
    }

    void Flip()
    {
        _facingRight = !_facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
