using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _launchOffset;

    [Range(0f, 2f)]
    [SerializeField] private float _firingRate = 1.0f;

    private float _fireTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && _fireTimer <= 0)
        {
            Shoot();
            _fireTimer = _firingRate;
        }
        else
        {
            _fireTimer -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        Instantiate(_bulletPrefab, _launchOffset.position, _launchOffset.rotation);
    }
}
