using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image battery;
    public Text batteryCount;
    public Image vodka;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    private PlayerStatus status;

    private void Start()
    {
        status = FindObjectOfType<PlayerStatus>();
    }

    private void Update()
    {
        battery.fillAmount = status.currentBatery * 0.01f;
        batteryCount.text = "x " + status.batteries.ToString();
        vodka.fillAmount = status.stamina * 0.01f;
        CheckLives();
    }

    private void CheckLives() {
        life1.SetActive(status.health > 1f);
        life2.SetActive(status.health > 34f);
        life3.SetActive(status.health > 67f);
    }
}
