using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] posEnemy;
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public int enemy1ToSpawn;
    public int enemy2ToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemy1ToSpawn; i++)
        {
            int indexSelected = Random.Range(0, posEnemy.Length - 1);
            Instantiate(enemy1Prefab, posEnemy[indexSelected].position, Quaternion.identity);
        }
        for (int i = 0; i < enemy2ToSpawn; i++)
        {
            int indexSelected = Random.Range(0, posEnemy.Length - 1);
            Instantiate(enemy1Prefab, posEnemy[indexSelected].position, Quaternion.identity);
        }
    }
}
