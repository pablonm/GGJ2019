using UnityEngine;

public class LeaveHouse : ActionableObject
{
    public SpriteRenderer sprite;

    private void Start()
    {
        sprite.gameObject.SetActive(false);
    }

    protected override void Action()
    {
        // TODO: Leave house
    }

    protected override void OnEnter()
    {
        sprite.gameObject.SetActive(true);
    }

    protected override void OnExit()
    {
        sprite.gameObject.SetActive(false);
    }
}
