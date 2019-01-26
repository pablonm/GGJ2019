using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchableObject : ActionableObject
{
    public float rate;

    private PlayerStatus status;

    void Start()
    {
        status = FindObjectOfType<PlayerStatus>();
        Random.InitState(System.DateTime.Now.Millisecond);
    }

    protected override void Action()
    {
        status.batteries += Mathf.Min(GlobalSettings.maxBattery, Mathf.FloorToInt(Random.Range(0f, GlobalSettings.betteryRate)));
        status.stamina += Mathf.Min(GlobalSettings.maxStamina, Mathf.FloorToInt(Random.Range(0f, GlobalSettings.vodkaRate)));
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
