using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    public float vel = 5;
    public float velPatrol = 1;
    public float DistanceThreshold = 6;
    public bool patrol = true;
    public float angleChangeInterval = 1;

    private Transform player;
    private Vector2 vectorPatrol;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
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
                Move(normV, vel);
            }
            else
            {
                player = null;
                StartCoroutine(RegenenateVector());
            }
        }
        else
        {
            if (patrol)
            {
                Move(vectorPatrol, velPatrol);
               
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

    public abstract void Initialize();
    public abstract void Move(Vector2 v, float vel);
    public abstract void Stop();
}
