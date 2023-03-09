using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField]
    private Sprite sprite;

    virtual public void Apply(Player player)
    {
        
    }

    public Sprite getSprite()
    {
        return sprite;
    }
}
