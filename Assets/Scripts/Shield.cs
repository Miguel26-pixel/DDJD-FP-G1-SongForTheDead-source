using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : PowerUp
{
    [SerializeField] float duration;
    [SerializeField] Color playerColor;
    public override void Apply(Player player)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(ActivateSpeedUp(player));
    }

    private IEnumerator ActivateSpeedUp(Player player)
    {
        player.SetShield(true);
        Color originalColor = player.GetComponent<SpriteRenderer>().color;
        player.GetComponent<SpriteRenderer>().color = playerColor;

        yield return new WaitForSeconds(duration);

        player.SetShield(false);
        player.GetComponent<SpriteRenderer>().color = originalColor;
        Destroy(gameObject);
    }
}
