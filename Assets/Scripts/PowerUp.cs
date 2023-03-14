using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField]
    private Sprite sprite;
    private float timeLeft = 10;
    private bool isUp = false;

    public void Update()
    {
        if (isUp)
        {
            setTimeLeft(timeLeft-Time.deltaTime);
        }
        if (timeLeft <= 0)
        {
            isUp = false;
        }
    }

    virtual public void Apply(Player player)
    {
        
    }

    public Sprite getSprite()
    {
        return sprite;
    }

    public float getTimeLeft()
    {
        return timeLeft;
    }

    public void setTimeLeft(float time)
    {
        timeLeft = time;
    }

    public bool getIsUp()
    {
        return isUp;
    }

    public void setIsUp(bool what)
    {
        isUp = what;
    }
}
