using UnityEngine;

public class Demon : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float checkRadius;
    [SerializeField] private float attackRadius;
    [SerializeField] private float damage;
    [SerializeField] private float health = 50;
    [SerializeField] private bool shouldRotate;

    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Player playerTarget;

    private Rigidbody2D rb;
    private Animator anim;

    private bool isInChaseRange;
    private bool isInAttackRange;

    private ScoreSystem scoreSystem;

    [SerializeField] private float timeBetweenAttacks = 3f;
    private float attackTimer = 0f;

    [SerializeField]
    private AudioSource hurtSoundEffect;

    [SerializeField]
    private AudioSource attackSoundEffect;

    [SerializeField]
    private AudioSource deathSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerTarget = GameObject.FindWithTag("Player")?.GetComponent<Player>();
        anim.SetBool("isAlive", true);
        scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    private void Update()
    {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        if (playerTarget != null)
        {
            var dir = playerTarget.transform.position - transform.position;
            dir.Normalize();
            rb.velocity = dir * speed;
        }

        if (shouldRotate)
        {
            anim.SetFloat("x", rb.velocity.x);
            anim.SetFloat("y", rb.velocity.y);
        }

        anim.SetBool("isRunning", isInChaseRange);
        anim.SetBool("isToAttack", isInAttackRange);

        attackTimer += Time.deltaTime;

        if (attackTimer >= timeBetweenAttacks)
        {
            Attack();
            attackTimer = 0f;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        hurtSoundEffect.Play();
        if (health <= 0)
        {
            deathSoundEffect.Play();
            scoreSystem.IncrementScore();
            Destroy(gameObject);
        }
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
            playerTarget = other.gameObject.GetComponent<Player>();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    void Attack()
    {
        if (isInAttackRange && playerTarget != null)
        {
            attackSoundEffect.Play();
            playerTarget.TakeDamage(damage);
        }
    }
}
