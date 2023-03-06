using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : PowerUp
{
    [SerializeField] float speedMultiplier;
    [SerializeField] float duration;

    public override void Apply(Player player)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(ActivateSpeedUp(player));
    }

    private IEnumerator ActivateSpeedUp(Player player)
    {
        PlayerMovement movement = player.GetComponent<PlayerMovement>();

        float originalSpeed = movement.GetSpeed();
        movement.SetSpeed(originalSpeed * speedMultiplier);

        yield return new WaitForSeconds(duration);

        movement.SetSpeed(originalSpeed);
        Debug.Log("Back to original speed of " + originalSpeed);
        Destroy(gameObject);
    }
}
