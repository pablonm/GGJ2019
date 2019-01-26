using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private float health;

    void Start()
    {
        health = GlobalSettings.maxEnemyLife;
    }

    private void TakeDamage()
    {
        Debug.Log(health);

        health -= Time.deltaTime * GlobalSettings.lightDamage;  

         if (health < 0)
        {
            Debug.Log("Mori xD");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Light"))
        {
            TakeDamage();
        }
    }
}
