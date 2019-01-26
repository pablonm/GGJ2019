using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHouse : ActionableObject
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = FindObjectOfType<PlayerStatus>().GetComponent<Rigidbody2D>();
    }

    protected override void Action()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
        MapTransition.GoTo("House", "SpawnFromMap");
    }

    protected override void OnEnter() {}

    protected override void OnExit() {}
}
