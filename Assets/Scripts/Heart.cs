using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp
{

    [SerializeField] private float healthPoints;

    override public void Apply(Player player)
    {
        Debug.Log("Picked a heart!");
        Debug.Log("Current health points " + player.GetHealth());
        float health = player.GetHealth();

        if (health == player.GetMaxHealth())
        {
            return;
        }

        Debug.Log("New health " + (health + healthPoints));

        player.SetHealth(health + healthPoints);
        Destroy(gameObject);
    }
}
