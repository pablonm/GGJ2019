using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchableObject : ActionableObject
{
    public float rate;

    private PlayerStatus status;
    private GlobalSettings globalSettings;

    void Start()
    {
        status = FindObjectOfType<PlayerStatus>();
        globalSettings = FindObjectOfType<GlobalSettings>();
        Random.InitState(System.DateTime.Now.Millisecond);
    }

    protected override void Action()
    {
        status.batteries += Mathf.Min(globalSettings.maxBattery, Mathf.FloorToInt(Random.Range(0f, globalSettings.betteryRate)));
        status.stamina += Mathf.Min(globalSettings.maxStamina, Mathf.FloorToInt(Random.Range(0f, globalSettings.vodkaRate)));
    }

    protected override void OnEnter()
    {
        return;
    }

    protected override void OnExit()
    {
        return;
    }
}
