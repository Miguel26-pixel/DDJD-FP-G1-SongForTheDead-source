using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float _damage;
    public float _range;
    public float _fireRate;
    public Sprite sprite;

    public virtual void Fire()
    {

    }

    public Sprite getSprite()
    {
        return sprite;
    }
}
