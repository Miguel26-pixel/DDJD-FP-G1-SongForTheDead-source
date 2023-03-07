using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Weapons")]
    [SerializeField] private List<Weapon> weapons = new List<Weapon>();
    [SerializeField] private Weapon currentWeapon = null;

    [Header("Stats")]
    [SerializeField] private float health = 5f;

    private PlayerMovement playerMovement = null;

    public static bool playerControles = true;

    [SerializeField]
    private AudioSource hitSoundEffect;

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
    }


    public void TakeDamage(float damage)
    {
        health -= damage;
        hitSoundEffect.Play();
        if (health <= 0f)
        {
            Debug.Log("Player died");
            Destroy(gameObject, 0.5f);
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
}
