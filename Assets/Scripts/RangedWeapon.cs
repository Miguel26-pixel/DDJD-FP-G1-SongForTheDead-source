using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    public GameObject _projectilePrefab;
    public Transform _firePoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Fire()
    {
        base.Fire();
        Vector3 screenPos = Camera.main.WorldToScreenPoint(_firePoint.position);
        Vector3 shootingDirection = (Input.mousePosition - screenPos).normalized;

        GameObject bullet = Instantiate(_projectilePrefab, _firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootingDirection.x, shootingDirection.y) * _fireRate;
    }
}
