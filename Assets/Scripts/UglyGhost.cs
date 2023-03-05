using UnityEngine;

public class UglyGhost : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float checkRadius;
    [SerializeField] private float attackRadius;
    [SerializeField] private float damage;
    [SerializeField] private float health = 3;
    [SerializeField] private bool shouldRotate;

    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Player playerTarget;

    [SerializeField] private float knockbackForce = 10f;

    private Rigidbody2D rb;
    private Animator anim;

    private bool isInChaseRange;

    private ScoreSystem scoreSystem;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerTarget = GameObject.FindWithTag("Player")?.GetComponent<Player>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    private void Update()
    {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);

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


    }
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
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