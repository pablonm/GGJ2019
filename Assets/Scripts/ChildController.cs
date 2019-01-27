using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChildController : MonoBehaviour
{
    public enum Buttons { A, LT }
    public Buttons button;
    public string message;
    public float minDist = 0.2f;
    public float maxDist = 0.5f;
    private bool grabbing = false;
    private bool running = false;
    private float offset;
    private Transform sprite;
    Rigidbody2D rb;
    Transform player;
    Animator anim;
    private GameObject actionMessagePrefab;

    private void Awake()
    {
        LoadResources();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sprite = transform.GetChild(0);
        anim = sprite.GetComponent<Animator>();
        offset = transform.position.y - sprite.transform.position.y;
    }

    private void LoadResources()
    {
        actionMessagePrefab = Resources.Load<GameObject>("ActionMessage");
        Sprite buttonSprite = null;
        switch (button)
        {
            case Buttons.A:
                buttonSprite = Resources.Load<Sprite>("A");
                break;
            case Buttons.LT:
                buttonSprite = Resources.Load<Sprite>("LT");
                break;
        }
        actionMessagePrefab = Instantiate(actionMessagePrefab, transform);
        actionMessagePrefab.transform.Find("Message").GetComponent<Text>().text = message;
        actionMessagePrefab.transform.Find("Button").GetComponent<Image>().sprite = buttonSprite;
        actionMessagePrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbing)
        {
            float distance = Vector2.Distance(sprite.position, player.position);
            if (distance < maxDist && distance > minDist)
            {
                Move(new Vector2(player.position.x - sprite.position.x, player.position.y - sprite.position.y));
            }
            else
            {
                Stop();
            }
        }
        else
        {
            Stop();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bool grabbing = Input.GetAxis("Fire2") > 0;
            if (grabbing != this.grabbing)
            {
                player = collision.gameObject.transform;
                this.grabbing = grabbing;
                collision.gameObject.GetComponent<PlayerMovement>().grabChild(grabbing);
            }
            if (!grabbing)
            {
                actionMessagePrefab.SetActive(true);
            }
            else
            {
                actionMessagePrefab.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.grabbing = false;
            collision.gameObject.GetComponent<PlayerMovement>().grabChild(false);
            actionMessagePrefab.SetActive(false);
        }
    }

    private void Move(Vector2 v)
    {
        rb.velocity = Helper.NormalizeVector(v.x, v.y) * 1.05f;
        if (v.x > 0)
        {
            if (sprite.localScale.x < 0)
            {
                Flip();
            }
        }
        else
        {
            if (sprite.localScale.x > 0)
            {
                Flip();
            }
        }
        if (!running)
        {
            running = true;
            anim.SetBool("running", true);
        }
    }

    private void Stop()
    {
        rb.velocity = new Vector2(0, 0);
        if (running)
        {
            running = false;
            anim.SetBool("running", false);
        }
    }

    private void Flip()
    {
        sprite.localScale = new Vector2(-sprite.localScale.x, sprite.localScale.y);
    }
}
