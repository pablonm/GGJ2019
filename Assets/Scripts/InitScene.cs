using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScene : MonoBehaviour
{
    public Transform cameraTarget;
    public float EnemyDebuff;
    void Start()
    {
        GlobalSettings.cameraTarget = cameraTarget;
        GlobalSettings.EnemyDebuff = EnemyDebuff;
    }
}
