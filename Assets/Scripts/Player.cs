using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Weapons
    public List<Weapon> _weapons;
    public Weapon _currentWeapon;
    public int _currentWeaponIndex = 0;

    // Moving
    private Animator _animator;
    public Vector3 _speed = new Vector3(10, 10);
    private bool _facingRight = true;

    // Attacking
    [SerializeField]
    private Bullet _projectilePrefab;
    [SerializeField]
    private Transform _lauchOffset;

    // Stats
    private float _health = 5;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

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

        // Hide all weapons except the current one
        for (int i = 0; i < _weapons.Count; i++)
        {
            _weapons[i].gameObject.SetActive(i == _currentWeaponIndex);
        }

        // Update current weapon
        if (_weapons.Count > 0)
        {
            _currentWeapon = _weapons[_currentWeaponIndex];
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _currentWeaponIndex = (_currentWeaponIndex + 1) % _weapons.Count;
            _currentWeapon = _weapons[_currentWeaponIndex];
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (_currentWeapon)
            {
                _currentWeapon.Fire();
            }
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        Debug.Log("Health: "+ _health.ToString());

        if (_health <= 0)
        {
            Debug.Log("Player died");
            Destroy(gameObject);
        }
    }

    void Flip()
    {
        _facingRight = !_facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Weapon newWeapon = other.GetComponent<Weapon>();

        if (newWeapon != null && !_weapons.Contains(newWeapon))
        {
            // Add the new weapon to the player's list of weapons
            _weapons.Add(newWeapon);

            // Set the weapon as a child of the player and position/rotate it
            newWeapon.transform.SetParent(transform);
            newWeapon.transform.localPosition = new Vector3(0.15f, 0f, 0f);
            newWeapon.transform.localRotation = Quaternion.identity;

            // Make the newly acquired weapon the current selected one
            _currentWeaponIndex = _weapons.IndexOf(newWeapon);

        }
    }
}
