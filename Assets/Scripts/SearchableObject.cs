using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchableObject : MonoBehaviour
{
    public float rate;

    private bool isOpened;
    private PlayerStatus status;
    private GlobalSettings globalSettings;
    private Random randomer;

    void Start()
    {
        isOpened = false;
        status = FindObjectOfType<PlayerStatus>();
        globalSettings = FindObjectOfType<GlobalSettings>();
        Random.InitState(System.DateTime.Now.Millisecond);
    }

    private void DiscoverRandomObject()
    {
        isOpened = true;
        status.batteries += Mathf.Min(globalSettings.maxBattery, Mathf.FloorToInt(Random.Range(0f, globalSettings.betteryRate)));
        status.stamina += Mathf.Min(globalSettings.maxStamina, Mathf.FloorToInt(Random.Range(0f, globalSettings.vodkaRate)));
        Debug.Log(status.batteries);
        Debug.Log(status.stamina);
    }

    private void OnTriggerStay2D(Collider2D colider)
    {
        if (!isOpened && (colider.tag == "Player") && Input.GetKeyDown(KeyCode.Space))
        {
            DiscoverRandomObject();
        }
    }
}
