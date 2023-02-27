using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    public float swingTime;
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

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _range);

        foreach (Collider2D collider in colliders)
        {
            MiniGhost enemy = collider.GetComponent<MiniGhost>();

            if (enemy != null)
            {
                Debug.Log("Guitar hit on " + enemy.name);
                enemy.TakeDamage(_damage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
