﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : EnemyMovement
{
    public float zigzagAmplitude = 3;
    public float zigzagVel = 3;
    private float angle = 0;
    public float hitInterval = 1f;

    public override void Initialize()
    {
        playerStatus = FindObjectOfType<PlayerStatus>();
        health = GlobalSettings.maxEnemyLife;
    }

    public override void Move(Vector2 v, float vel)
    {
        Vector2 desviation = Helper.OrthogonalVector(v) * Mathf.Cos(angle) * zigzagAmplitude;
        angle += 0.1f;
        rb.velocity = new Vector2((v.x + desviation.x) * vel, (v.y + desviation.y) * vel);
    }
}
