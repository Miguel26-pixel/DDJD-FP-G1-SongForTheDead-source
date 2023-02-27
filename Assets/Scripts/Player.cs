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

        if (_weapons.Count > 0)
        {
            _currentWeapon = _weapons[_currentWeaponIndex];
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Cycle through the player's equipped weapons
            _currentWeaponIndex++;
            if (_currentWeaponIndex >= _weapons.Count)
            {
                _currentWeaponIndex = 0;
            }

            _currentWeapon = _weapons[_currentWeaponIndex];
        }

        if (Input.GetButtonDown("Fire1"))
        {
            _currentWeapon.Fire();
        }
    }

    void Flip()
    {
        _facingRight = !_facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
        Weapon newWeapon = other.GetComponent<Weapon>();

        if (newWeapon != null)
        {
            // Add the new weapon to the player's list of weapons
            _weapons.Add(newWeapon);

            // Set the new weapon's parent to the player game object
            newWeapon.transform.SetParent(transform);

        }
    }
}
