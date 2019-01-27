using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renderOrder : MonoBehaviour
{
    SpriteRenderer sr;
    Transform t;
    SpriteMask sm;

    private void Start()
    {
        t = FindObjectOfType<PlayerStatus>().transform;
        sm = GetComponent<SpriteMask>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (transform.position.y < t.position.y)
        {
            sm.enabled = true;
        }
        else
        {
            sm.enabled = false;
        }
    }
}
