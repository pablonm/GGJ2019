using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EnemyMovement
{
    public float zigzagAmplitude = 3;
    public float zigzagVel = 3;
    private float angle = 0;
    private PlayerStatus playerStatus;
    public float hitInterval = 1f;

    public override void Initialize()
    {
        playerStatus = FindObjectOfType<PlayerStatus>();
    }

    public override void Move(Vector2 v, float vel)
    {
        Vector2 desviation = Helper.OrthogonalVector(v) * Mathf.Cos(angle) * zigzagAmplitude;
        angle += 0.1f;
        rb.velocity = new Vector2((v.x + desviation.x) * vel, (v.y + desviation.y) * vel);
    }

    public override void Stop()
    {
        rb.velocity = new Vector3(0, 0, 0);
    }

    private new void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStatus.health -= 34;
            Destroy(gameObject);
        }
        base.OnTriggerStay2D(collision);
    }
}
