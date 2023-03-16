using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PowerUpDisplay : MonoBehaviour
{
    private Weapon currentWeapon;

    [Header("Weapons")]
    [SerializeField] private float maxPowerUps;
    [SerializeField] private Sprite emptyBox;
    [SerializeField] private List<PowerUp> powerUps = new List<PowerUp>();
    [SerializeField] private Image[] boxes;
    [SerializeField] private Image[] boxesBehind;
    [SerializeField] private List<TMP_Text> texts = new List<TMP_Text>();

    private Player player;

    void Start()
    {
        player = GetComponent<Player>();
        currentWeapon = player.getCurrentWeapon();
        powerUps = player.GetPowerUps();
    }

    void Update()
    {
        powerUps = player.GetPowerUps();
        for (int i = 0; i < boxes.Count(); i++)
        {
            if (i >= powerUps.Count)
            {
                boxes[i].sprite = emptyBox;
                texts[i].text = "0 s";
            }
        }
        for (int i = 0; i < powerUps.Count; i++)
        {
            boxes[i].sprite = powerUps[i].getSprite();
            texts[i].text = ((int)powerUps[i].getTimeLeft()).ToString() + " s";
        }
    }
}
