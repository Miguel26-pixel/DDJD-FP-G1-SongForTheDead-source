using UnityEngine;

public class RangedWeapon : Weapon
{
    public GameObject _projectilePrefab;
    public Transform _firePoint;
    public Camera cam;
    [SerializeField]
    private AudioSource fireSoundEffect;   

    public override void Fire()
    {
        base.Fire();
        Vector3 screenPos = cam.WorldToScreenPoint(_firePoint.position);
        Vector3 shootingDirection = (Input.mousePosition - screenPos).normalized;
        fireSoundEffect.Play();
        GameObject bullet = Instantiate(_projectilePrefab, _firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootingDirection.x, shootingDirection.y) * _fireRate;
        bullet.GetComponent<Bullet>().setDamage(_damage);
    }
}
