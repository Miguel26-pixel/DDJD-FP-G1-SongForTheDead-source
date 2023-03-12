
using UnityEngine;

public class DrumsWeapon : Weapon
{
    public GameObject _projectilePrefab;
    public Transform _firePoint;
    public Camera cam;
    [SerializeField]
    private AudioSource fireSoundEffect;   

    public override void Fire()
    {
        base.Fire();
        Vector3 screenPos = new Vector3(5,5,0);
        Vector3 shootingDirection = screenPos.normalized;
        fireSoundEffect.Play();
        GameObject bullet = Instantiate(_projectilePrefab, _firePoint.position+ new Vector3(1,1,0), Quaternion.identity);
        GameObject bullet2 = Instantiate(_projectilePrefab, _firePoint.position+ new Vector3(-1,1,0), Quaternion.identity);
        GameObject bullet3 = Instantiate(_projectilePrefab, _firePoint.position+ new Vector3(1,-1,0), Quaternion.identity);
        GameObject bullet4 = Instantiate(_projectilePrefab, _firePoint.position+ new Vector3(-1,-1,0), Quaternion.identity);
        GameObject bullet5 = Instantiate(_projectilePrefab, _firePoint.position+ new Vector3(0,1,0), Quaternion.identity);
        GameObject bullet6 = Instantiate(_projectilePrefab, _firePoint.position+ new Vector3(1,0,0), Quaternion.identity);
        GameObject bullet7 = Instantiate(_projectilePrefab, _firePoint.position+ new Vector3(0,-1,0), Quaternion.identity);
        GameObject bullet8 = Instantiate(_projectilePrefab, _firePoint.position+ new Vector3(-1,0,0), Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootingDirection.x, shootingDirection.y) * _fireRate;
        bullet.GetComponent<Bullet>().setDamage(_damage);
        bullet2.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootingDirection.x, shootingDirection.y) * _fireRate;
        bullet2.GetComponent<Bullet>().setDamage(_damage);
        bullet3.GetComponent<Rigidbody2D>().velocity = new Vector2(shootingDirection.x, -shootingDirection.y) * _fireRate;
        bullet3.GetComponent<Bullet>().setDamage(_damage);
        bullet4.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootingDirection.x, -shootingDirection.y) * _fireRate;
        bullet4.GetComponent<Bullet>().setDamage(_damage);
        bullet5.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shootingDirection.y) * _fireRate;
        bullet5.GetComponent<Bullet>().setDamage(_damage);
        bullet6.GetComponent<Rigidbody2D>().velocity = new Vector2(shootingDirection.x, 0) * _fireRate;
        bullet6.GetComponent<Bullet>().setDamage(_damage);
        bullet7.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -shootingDirection.y) * _fireRate;
        bullet7.GetComponent<Bullet>().setDamage(_damage);
        bullet8.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootingDirection.x, 0) * _fireRate;
        bullet8.GetComponent<Bullet>().setDamage(_damage);
    }
}
