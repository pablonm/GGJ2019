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

    // Start is called before the first frame update
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
        status.batteries += Mathf.FloorToInt(Random.Range(0f, globalSettings.betteryRate));
        if (status.batteries > globalSettings.maxBattery)
        {
            status.batteries = globalSettings.maxBattery;
        }
        status.stamina += Mathf.FloorToInt(Random.Range(0f, globalSettings.vodkaRate));
        if (status.stamina > globalSettings.maxStamina)
        {
            status.stamina = globalSettings.maxStamina;
        }
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
