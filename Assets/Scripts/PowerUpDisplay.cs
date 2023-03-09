using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpDisplay : MonoBehaviour
{
    private Weapon currentWeapon;

    [Header("Weapons")]
    [SerializeField] private float maxPowerUps;
    [SerializeField] private Sprite emptyBox;
    [SerializeField] private List<PowerUp> powerUps = new List<PowerUp>();
    [SerializeField] private Image[] boxes;
    [SerializeField] private Image[] boxesBehind;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        currentWeapon = player.getCurrentWeapon();
        powerUps = player.GetPowerUps();
    }

    // Update is called once per frame
    void Update()
    {
        powerUps = player.GetPowerUps();
        for (int i = 0; i < boxes.Count(); i++)
        {
            if (i >= powerUps.Count)
            {
                boxes[i].sprite = emptyBox;
            }
        }
        for (int i = 0; i < powerUps.Count; i++)
        {
            boxes[i].sprite = powerUps[i].getSprite();
        }

    }
}
