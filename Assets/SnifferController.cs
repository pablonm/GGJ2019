using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnifferController : MonoBehaviour
{
    EnemyMovement Enemy;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = this.transform.parent.GetComponent<EnemyMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Enemy.findPlayer(collision.transform);
        }
    }
}
