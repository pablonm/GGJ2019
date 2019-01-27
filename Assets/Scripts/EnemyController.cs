using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EnemyMovement
{
    private PlayerStatus playerStatus;
    public float hitInterval = 1f;

    public override void Initialize()
    {
        playerStatus = FindObjectOfType<PlayerStatus>();
    }

    public override void Move(Vector2 v, float vel)
    {
        rb.velocity = new Vector2(v.x * vel, v.y * vel);
    }

}
