using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkingSpeed = 1f;
    public float runningSpeed = 2f;
    public float staminaConsumption = 40f;

    private PlayerStatus status;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private void Start()
    {
        status = FindObjectOfType<PlayerStatus>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float speed = walkingSpeed;
        if (!status.recharging && !status.grabbingChild && status.stamina > 0)
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
        if (status.health < 0)
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void grabChild(bool g)
    {
        status.grabbingChild = g;
    }
}
