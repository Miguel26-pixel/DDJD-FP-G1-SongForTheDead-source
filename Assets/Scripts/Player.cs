using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Weapons")]
    [SerializeField] private List<Weapon> weapons = new List<Weapon>();
    [SerializeField] private Weapon currentWeapon = null;

    [Header("Stats")]
    [SerializeField] private float health = 5f;
    [SerializeField] private float maxHealth = 5f;

    private PlayerMovement playerMovement = null;

    public static bool playerControles = true;

    [SerializeField]
    private AudioSource hitSoundEffect;

    public GameObject cam1;
    public GameObject cam2;

    [SerializeField]
    private AudioSource IntroSound;

    [SerializeField]
    private AudioSource MainSound;
    private bool hasShield = false;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        // Movement
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(inputX, inputY, 0f);
        playerMovement.Move(movement);

        // Weapon selection
        if (Input.GetKeyDown(KeyCode.Tab) && weapons.Count > 0)
        {
            currentWeapon.gameObject.SetActive(false);
            int nextIndex = (weapons.IndexOf(currentWeapon) + 1) % weapons.Count;
            currentWeapon = weapons[nextIndex];
            currentWeapon.gameObject.SetActive(true);
        }

        // Weapon firing
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentWeapon)
            {
                currentWeapon.Fire();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Weapon newWeapon = other.GetComponent<Weapon>();
        PowerUp newPowerUp = other.GetComponent<PowerUp>();

        if (newWeapon && !weapons.Contains(newWeapon))
        {
            // Deactivate the current weapon, if there is one
            if (currentWeapon)
            {
                currentWeapon.gameObject.SetActive(false);
            }

            // Add the new weapon to the player's list of weapons
            weapons.Add(newWeapon);

            // Set the weapon as a child of the player and position/rotate it
            newWeapon.transform.SetParent(transform);
            newWeapon.transform.localPosition = new Vector3(0.15f, 0f, 0f);
            newWeapon.transform.localRotation = Quaternion.identity;

            // Make the newly acquired weapon the current selected one
            currentWeapon = newWeapon;
            currentWeapon.gameObject.SetActive(true);
        }
        else if (newPowerUp)
        {
            Debug.Log("Picked up powerup");
            newPowerUp.Apply(this);
        }
    }


    public void TakeDamage(float damage)
    {
        if (hasShield)
        {
            return;
        }

        health -= damage;
        hitSoundEffect.Play();

        if (health <= 0f)
        { 
            Destroy(gameObject, 0.5f);
            cam1.SetActive(false);
            cam2.SetActive(true);

        }
    }

    public float getHealth()
    {
        return health;
    }

    public Weapon getCurrentWeapon()
    {
        return currentWeapon;
    }

    public List<Weapon> getWeaponsOn()
    {
        return weapons;
    }

    public void setHealth(float newHealth)
    {
        health = newHealth;
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }

    public void SetShield(bool newShield)
    {
            hasShield = newShield;
    }
}
