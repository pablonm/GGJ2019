using UnityEngine;

public class GrabFlashlight : ActionableObject
{
    public SpriteRenderer sprite;
    public Sprite normalFlashlight;
    public Sprite highlightFlashlight;

    private void Start()
    {
        Debug.Log("ASDASD");
    }

    protected override void Action()
    {
        // NADA
    }

    protected override void OnEnter()
    {
        // NADA
    }

    protected override void OnExit()
    {
        // NADA
    }
}
