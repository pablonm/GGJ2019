using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float vel = 5;
    public float velPatrol = 1;
    public float angleChangeInterval = 1;
    public float DistanceThreshold = 6;
    public bool patrol = true;
    private Rigidbody2D rb;
    private Transform player;
    private Vector2 vectorPatrol;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponentInChildren<Rigidbody2D>();
        StartCoroutine(RegenenateVector());
    }

    private void Update()
    {
        if (player)
        {
            float distance = Helper.Distance(this.transform.position, player.position);
            if (distance < DistanceThreshold)
            {
                Vector2 normV = Helper.NormalizeVector(new Vector2(player.position.x - this.transform.position.x, player.position.y - this.transform.position.y), distance);
                rb.velocity = new Vector3(vel * normV.x, vel * normV.y, 0);
            }
            else
            {
                player = null;
                rb.velocity = new Vector3(0, 0, 0);
                StartCoroutine(RegenenateVector());
            }
        }
        else
        {
            if (patrol)
            {
                rb.velocity = new Vector3(vectorPatrol.x * velPatrol, vectorPatrol.y * velPatrol, 0);
            }
        }
    }

    public void findPlayer(Transform t)
    {
        player = t;
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
}
