using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playIndicator;
    public GameObject exitIndicator;
    private bool play = true;

    private void Update()
    {
        if (Input.GetAxis("Vertical") > 0) {
            playIndicator.SetActive(true);
            exitIndicator.SetActive(false);
            play = true;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            playIndicator.SetActive(false);
            exitIndicator.SetActive(true);
            play = false;
        }
        if (Input.GetAxis("Action") > 0) {
            if (play)
                SceneManager.LoadScene("Game");
            else
                Application.Quit();
        }
    }
}
