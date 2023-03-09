using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : PowerUp
{
    [SerializeField] float duration;
    public override void Apply(Player player)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(ActivateSpeedUp(player));
    }

    private IEnumerator ActivateSpeedUp(Player player)
    {
        player.SetShield(true);
        player.AddPowerUp(this);

        yield return new WaitForSeconds(duration);

        Debug.Log("End of power-up");
        player.RemovePowerUp(this);
        player.SetShield(false);
        Destroy(gameObject);
    }
}
