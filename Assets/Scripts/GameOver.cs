using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetAxis("Action") > 0) {
            SceneManager.LoadScene("Menu");
        }
    }
}
