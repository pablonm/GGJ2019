using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    private float health;
    public enum State { Idle, Following, Dying };
    public State state = State.Idle;
    public float vel = 5;
    public float velPatrol = 1;
    public float DistanceThreshold = 6;
    public bool patrol = true;
    public float angleChangeInterval = 1;
    private bool takingDamage = false;
    public Rigidbody2D rb;
    private bool isRight = false;

    private Transform player;
    private Vector2 vectorPatrol = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Initialize();
        health = GlobalSettings.maxEnemyLife;
        StartCoroutine(RegenenateVector());
    }

    public void Update()
    {
        float vel = this.vel;
        float velPatrol = this.velPatrol;
        if (takingDamage)
        {
            vel *= GlobalSettings.EnemyDebuff;
            velPatrol *= GlobalSettings.EnemyDebuff;
            takingDamage = false;
        }
        switch (state)
        {
            case State.Idle:
                Move(vectorPatrol, velPatrol);
                break;
            case State.Following:
                float distance = Helper.Distance(this.transform.position, player.position);
                if (distance < DistanceThreshold)
                {
                    Vector2 normV = Helper.NormalizeVector(new Vector2(player.position.x - this.transform.position.x, player.position.y - this.transform.position.y), distance);
                    Move(normV, vel);
                }
                else
                {
                    state = State.Idle;
                    StartCoroutine(RegenenateVector());
                };
                break;
        }
    }

    public void FixedUpdate()
    {
        if (rb.velocity.x > 0)
        {
            if (!isRight)
            {
                isRight = true;
                this.transform.localScale = new Vector2(-this.transform.localScale.x, this.transform.localScale.y);
            }
        }
        else
        {
            if (isRight)
            {
                isRight = false;
                this.transform.localScale = new Vector2(-this.transform.localScale.x, this.transform.localScale.y);
            }
        }
        
    }

    private void TakeDamage()
    {
        health -= Time.deltaTime * GlobalSettings.lightDamage;

        if (health < 0)
        {
            Death();
        }
    }

    public void findPlayer(Transform t)
    {
        player = t;
        state = State.Following;
    }

    IEnumerator RegenenateVector()
    {
        float randomAngle = Random.Range(0, 360);
        this.vectorPatrol = new Vector2(Mathf.Sin(randomAngle), Mathf.Cos(randomAngle));
        yield return new WaitForSeconds(angleChangeInterval);
        if (!player)
        {
            StartCoroutine(RegenenateVector());
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Light"))
        {
            TakeDamage();
            takingDamage = true;
        }
    }


    public abstract void Initialize();
    public abstract void Move(Vector2 v, float vel);
    public virtual void Death()
    {
        Destroy(gameObject);
    }
}
