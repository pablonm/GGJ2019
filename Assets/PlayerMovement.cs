using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkingSpeed = 1f;
    public float runningSpeed = 2f;
    public float staminaConsumption = 40f;

    private PlayerStatus status;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Start()
    {
        status = FindObjectOfType<PlayerStatus>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float speed = walkingSpeed;
        if (!status.recharging && status.stamina > 0)
        {
            status.running = Input.GetAxis("Fire2") > 0;
            if (status.running)
            {
                status.stamina -= Time.deltaTime * staminaConsumption;
                speed = runningSpeed;
            }
        }
        else
        {
            status.running = false;
            rb.velocity = Vector2.zero;
        }
        if (status.health > 0 && !status.recharging)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
        }

        if (rb.velocity.x != 0 && !status.usingFlashlight)
        {
            sprite.flipX = rb.velocity.x < 0;
        }
        animator.SetFloat("walking", rb.velocity.magnitude);
    }
}
