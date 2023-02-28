using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override void Fire()
    {
        base.Fire();

        _animator.SetTrigger("isAttacking");

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _range);

        foreach (Collider2D collider in colliders)
        {
            MiniGhost enemy = collider.GetComponent<MiniGhost>();

            if (enemy != null)
            {
                enemy.TakeDamage(_damage);
            }
        }
    }
}
