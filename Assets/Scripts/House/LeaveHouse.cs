using UnityEngine;

public class LeaveHouse : ActionableObject
{
    public SpriteRenderer sprite;
    private Rigidbody2D rb;
    private void Start()
    {
        sprite.gameObject.SetActive(false);
        rb = FindObjectOfType<PlayerStatus>().GetComponent<Rigidbody2D>();
    }

    protected override void Action()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        MapTransition.GoTo("Map", "SpawnFromHouse");
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
