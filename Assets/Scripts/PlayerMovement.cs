using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private Animator animator = null;
    private bool facingRight = true;

    private Vector3 currentMovement = Vector3.zero;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Move(Vector3 movement)
    {
        if (enabled)
        {
            // Normalize movement vector
            movement = movement.normalized;

            currentMovement = movement;
            transform.position += movement * speed * Time.deltaTime;

            // Animation
            bool isWalking = (movement.x != 0f || movement.y != 0f);
            animator.SetBool("isWalking", isWalking);

            // Flip sprite if moving left/right
            if ((facingRight && movement.x < 0f) || (!facingRight && movement.x > 0f))
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
