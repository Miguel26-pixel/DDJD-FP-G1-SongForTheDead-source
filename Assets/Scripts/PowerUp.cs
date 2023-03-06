using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public void Apply(Player player)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Handle heart pickup logic
        Player player = other.GetComponent<Player>();
        if (player)
        {
            // Act on the player
            Apply(player);
        }
    }
}
