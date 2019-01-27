using UnityEngine;

public class GrabFirstBattery : ActionableObject
{
    public SpriteRenderer sprite;
    public Sprite normalFlashlight;
    public Sprite highlightFlashlight;

    private PlayerStatus status;

    private void Start()
    {
        status = FindObjectOfType<PlayerStatus>();
    }

    protected override void Action()
    {
        sprite.gameObject.SetActive(false);
        status.ObtainItems(1, 0);
    }

    protected override void OnEnter()
    {
        sprite.sprite = highlightFlashlight;
    }

    protected override void OnExit()
    {
        sprite.sprite = normalFlashlight;
    }
}
