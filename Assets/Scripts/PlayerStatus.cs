using System.Collections;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float health = 100f;
    public float stamina = 100f;
    public int batteries = 0;
    public float currentBatery = 100f;
    public bool running = false;
    public bool recharging = false;
    public bool usingFlashlight = false;
    public bool grabbingChild = false;
    public bool blockMovement = false;

    public Animator a;

    public void takeDamage(int dam)
    {
        if (health > 0) {
            health -= dam;
            if ( health < 1)
            {
                a.SetTrigger("die");
                // TODO call die routine in GameManager
            }
            else
            {
                a.SetTrigger("hit");
            }
        }
    }
}
