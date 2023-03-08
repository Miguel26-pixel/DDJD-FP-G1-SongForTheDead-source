using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private float currentHealth;
    [SerializeField] private float maxHealth;

    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private Sprite fullHeart;

    [SerializeField] private Image[] hearts;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        currentHealth = player.GetHealth();
    }

    // Update is called once per frame
    void Update()
    { 
        currentHealth = player == null ? 0 : player.GetHealth();
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = i >= currentHealth ? emptyHeart : fullHeart;
        }
    }
}
