using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UglyGhost : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float checkRadius;
    [SerializeField] private float attackRadius;
    [SerializeField] private float damage;
    [SerializeField] private float health = 3;
    [SerializeField] private bool shouldRotate;

    public bool shouldRotate;

    public LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    public ScoreSystem _scoreSystem;

    private bool isInChaseRange;
    private bool isInAttackRange;
    public float Health
    {
        set
        {
            _health = value;

            if (_health <= 0)
            {
                _scoreSystem.IncrementScore();
                Destroy(gameObject);
            }
        }
        get
        {
            return _health;
        }
    }

    public float _health = 5;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        var player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        _scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    private void Update()
    {

        anim.SetBool("isRunning", isInChaseRange);

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        if (target != null)
        {
            dir = target.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            dir.Normalize();
            movement = dir;
            if (shouldRotate)
            {
                anim.SetFloat("x", dir.x);
                anim.SetFloat("y", dir.y);
            }
        }

    }

    private void FixedUpdate()
    {

        if (isInChaseRange && !isInAttackRange)
        {
            MoveCharacter(movement);
        }
        if (isInAttackRange)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Bullets"))
        {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();
            TakeDamage(bullet.getDamage());
        }
        else if (other.gameObject.CompareTag("Player"))
        {

            // Damage the player
            playerTarget.TakeDamage(damage);

            // Knockback the player
            playerTarget = other.gameObject.GetComponent<Player>();

            // Get the direction from the enemy to the player
            Vector2 dir = (other.transform.position - transform.position).normalized;


            playerTarget.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            playerTarget.GetComponent<Rigidbody2D>().inertia = 0;

            playerTarget.GetComponent<PlayerMovement>().enabled = false;
            Invoke("EnablePlayerControles", 0.5f); //if then amount of time is long then reduce it to the value you want.

            playerTarget.GetComponent<Rigidbody2D>().AddForce(dir * knockbackForce, ForceMode2D.Impulse);
        }
    }


    private void EnablePlayerControles()
    {
        if (playerTarget ==  null)
        {
            return;
        }
        playerTarget.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        playerTarget.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        playerTarget.GetComponent<Rigidbody2D>().inertia = 0;
        playerTarget.GetComponent<PlayerMovement>().enabled = true;
    }
}
