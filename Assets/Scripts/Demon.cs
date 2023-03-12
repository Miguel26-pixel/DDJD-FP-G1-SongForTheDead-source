using UnityEngine;

public class Demon : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float checkRadius;
    [SerializeField] private float attackRadius;
    [SerializeField] private float damage;
    [SerializeField] private float firedamage = 1f;
    [SerializeField] private float health = 100;
    [SerializeField] private bool shouldRotate;
    [SerializeField] private bool isAlive = false;

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

    private Vector3 dir = Vector3.zero;

    private bool facingRight = true;

    public GameObject _projectilePrefab;
    public Transform _firePoint;
    public Camera cam;
    [SerializeField]
    private AudioSource fireSoundEffect;   

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerTarget = GameObject.FindWithTag("Player")?.GetComponent<Player>();
        anim.SetBool("isAlive", false);
        scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    private void Update()
    {
        if (isAlive) {
            isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
            isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

            if (playerTarget != null)
            {
                dir = playerTarget.transform.position - transform.position;
                dir.Normalize();
                rb.velocity = dir * speed;
            }

            if ((facingRight && dir.x <0) || (!facingRight && dir.x > 0))
            {
                Flip();
            }

            anim.SetBool("isRunning", isInChaseRange);
            anim.SetBool("isToAttack", isInAttackRange);

            attackTimer += Time.deltaTime;

            if (attackTimer >= timeBetweenAttacks)
            {
                Attack();
                Fire();
                attackTimer = 0f;
            }
        }
    }

    public void Fire()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(_firePoint.position);
        Vector3 shootingDirection = (_firePoint.position - playerTarget.transform.position).normalized;
        fireSoundEffect.Play();
        GameObject bullet = Instantiate(_projectilePrefab, _firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-(shootingDirection.x * Mathf.Abs(speed) * 1.5f), -(shootingDirection.y * Mathf.Abs(speed) * 1.5f));
        bullet.GetComponent<FireBall>().setDamage(firedamage);
    }


    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
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

    public void SetAlive()
    {
        anim.SetBool("isAlive", true);
        isAlive = true;
    }
}
