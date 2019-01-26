using System.Collections;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Transform flashlight;
    public float batteryConsumption = 20;
    public float rechargeTime = 2f;
    private PlayerStatus status;

    private void Start()
    {
        status = FindObjectOfType<PlayerStatus>();
    }

    private void Update()
    {
        bool pressingTrigger = Input.GetAxis("Fire1") > 0;
        if (status.health > 0 && status.currentBatery > 0 && !status.recharging)
        {
            status.usingFlashlight = pressingTrigger;
            flashlight.gameObject.SetActive(status.usingFlashlight);
            if (status.usingFlashlight)
            {
                status.currentBatery -= Time.deltaTime * batteryConsumption;
                flashlight.right = new Vector3(Input.GetAxis("Right Stick X"), Input.GetAxis("Right Stick Y"), 0);
            }
        }
        else
        {
            flashlight.gameObject.SetActive(false);
        }
        if (pressingTrigger && status.currentBatery <= 0 && status.batteries > 0 && !status.recharging)
        {
            StartCoroutine(Recharge());
        }
    }

    private IEnumerator Recharge()
    {
        status.recharging = true;
        yield return new WaitForSeconds(rechargeTime);
        status.recharging = false;
        status.batteries--;
        status.currentBatery = 100f;
        yield break;
    }
}
