using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    private Weapon currentWeapon;

    [Header("Weapons")]
    [SerializeField] private float maxWeapons;
    [SerializeField] private Sprite emptyBox;
    [SerializeField] private List<Weapon> weapons = new List<Weapon>();
    [SerializeField] private Image[] boxes;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        currentWeapon = player.getCurrentWeapon();
        weapons = player.getWeaponsOn(); 
    }

    // Update is called once per frame
    void Update()
    { 
        for (int i = 0; i < weapons.Count; i++)
        {
            boxes[i].sprite = weapons[i].getSprite();
        }
    }
}
