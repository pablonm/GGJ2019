using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScene : MonoBehaviour
{
    public Transform cameraTarget;
    void Start()
    {
        GlobalSettings.cameraTarget = cameraTarget;
    }
}
