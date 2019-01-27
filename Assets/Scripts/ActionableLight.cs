using UnityEngine;
using System.Collections;

public class ActionableLight : ActionableObject
{
    public GameObject ActivableLightObject;
    public SpriteRenderer sprite;
    public Sprite normalSprite;
    public Sprite highlightSprite;


    private void Start()
    {
        repeatable = false;
    }

    protected override void Action()
    {
        ActivableLightObject.SetActive(true);
        StartCoroutine(LightOff());
    }

    protected override void OnEnter()
    {
        sprite.sprite = highlightSprite;
    }

    protected override void OnExit()
    {
        sprite.sprite = normalSprite;
    }

    private IEnumerator LightOff() {
        yield return new WaitForSeconds(Random.Range(GlobalSettings.MinLightDuration, GlobalSettings.MaxLightDuration));
        ActivableLightObject.SetActive(false);
        yield break;
    }
}
