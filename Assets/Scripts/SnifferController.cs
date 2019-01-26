using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnifferController : MonoBehaviour
{
    public float enemyViewDistance = 2f;

    EnemyMovement Enemy;
    Transform player;


    void Start()
    {
        Enemy = transform.parent.GetComponent<EnemyMovement>();
        player = FindObjectOfType<PlayerStatus>().transform;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) <= enemyViewDistance)
        {
            Enemy.findPlayer(player);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Enemy.findPlayer(collision.transform);
        }
    }
}
