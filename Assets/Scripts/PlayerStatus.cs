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
        health -= dam;
        if ( health < 1)
        {
            a.SetTrigger("die");
            Debug.Log("Mori xd");
            //PlayerDead();
        }
        else
        {
            a.SetTrigger("hit");
        }
    }

    private IEnumerator PlayerDead()
    {
        yield return new WaitForSeconds(1f);
        GameManager.PlayerDead();
        yield break;
    }
}
