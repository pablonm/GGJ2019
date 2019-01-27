using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EnemyMovement
{
    public float hitInterval = 1f;

    public override void Initialize()
    {
        health = GlobalSettings.maxDogLife;
    }

    public override void Move(Vector2 v, float vel)
    {
        rb.velocity = new Vector2(v.x * vel, v.y * vel);
    }

}
