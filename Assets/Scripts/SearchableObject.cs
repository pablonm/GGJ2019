using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchableObject : ActionableObject
{
    public SpriteRenderer sprite;
    public Sprite normalSprite;
    public Sprite highlightSprite;
    public Animator anim;

    private PlayerStatus status;

    void Start()
    {
        repeatable = false;
        status = FindObjectOfType<PlayerStatus>();
        Random.InitState(System.DateTime.Now.Millisecond);
    }

    protected override void Action()
    {
        status.ObtainItems(Mathf.Min(GlobalSettings.maxBattery, Mathf.FloorToInt(Random.Range(0f, GlobalSettings.betteryRate))), Mathf.Min(GlobalSettings.maxStamina, Mathf.FloorToInt(Random.Range(0f, GlobalSettings.vodkaRate))));
        if (anim)
        {
            anim.SetTrigger("search");
        }
    }

    protected override void OnEnter()
    {
        sprite.sprite = highlightSprite;
    }

    protected override void OnExit()
    {
        sprite.sprite = normalSprite;
    }
}
