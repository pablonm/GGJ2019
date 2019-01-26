using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsController : MonoBehaviour
{
    public GameObject normal;
    public GameObject flashlight;
    public Rigidbody2D rb;

    private PlayerStatus status;

    private void Start()
    {
        status = FindObjectOfType<PlayerStatus>();
    }

    private void Update()
    {
        if (status.usingFlashlight)
        {
            flashlight.SetActive(true);
            normal.SetActive(false);
            flashlight.GetComponent<SpriteRenderer>().flipX = Input.GetAxis("Right Stick X") < 0;
            flashlight.GetComponent<Animator>().SetFloat("walking", rb.velocity.magnitude);
        }
        else
        {
            flashlight.SetActive(false);
            normal.SetActive(true);
            if (rb.velocity.x != 0)
            {
                normal.GetComponent<SpriteRenderer>().flipX = rb.velocity.x < 0;
            }
            normal.GetComponent<Animator>().SetFloat("walking", rb.velocity.magnitude);
        }
    }

    public void Recharge() {
        flashlight.SetActive(false);
        normal.SetActive(true);
        normal.GetComponent<Animator>().SetTrigger("recharge");
    }
}
