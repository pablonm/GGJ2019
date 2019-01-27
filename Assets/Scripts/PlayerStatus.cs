using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
    public Animator vodkaItemAnimator;
    public Animator bateryItemAnimator;
    public Transform hitSounds;
    public AudioSource deathSound;

    public Animator a;

    public void takeDamage(int dam)
    {
        if (health > 0) {
            health -= dam;
            if (health < 1)
            {
                deathSound.Play();
                a.SetTrigger("die");
                // TODO call die routine in GameManager
            }
            else
            {
                hitSounds.GetChild(Random.Range(0, 3)).GetComponent<AudioSource>().Play();
                a.SetTrigger("hit");
            }
        }
    }

    public void ObtainItems(int bat, float vodka)
    {
        batteries += bat;
        stamina += vodka;
        StartCoroutine(AnimateItems(bat, vodka));
    }

    private IEnumerator AnimateItems(int bat, float vodka) {
        if (bat > 0) {
            bateryItemAnimator.transform.Find("Text").GetComponent<Text>().text = "x" + bat.ToString();
            bateryItemAnimator.SetTrigger("obtain");
            yield return new WaitForSeconds(1f);
        }
        if (vodka > 0f) {
            vodkaItemAnimator.transform.Find("Text").GetComponent<Text>().text = "x" + vodka.ToString();
            vodkaItemAnimator.SetTrigger("obtain");
        }
        yield break;
    }
}
