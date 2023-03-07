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
    [SerializeField] private Image[] boxesBehind;

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
            if (weapons[i] == currentWeapon)
            {
                boxesBehind[i].transform.localScale = new Vector3(2.0f,2.0f,2.0f);
            }
            boxes[i].sprite = weapons[i].getSprite();
        }
    }
}
