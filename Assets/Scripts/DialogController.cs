using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public Text message;
    public AudioSource audioSource;

    private PlayerStatus status;

    private void Awake()
    {
        status = FindObjectOfType<PlayerStatus>();
    }

    public void ShowDialog(string text, AudioClip audio, float time, bool blocking) {
        message.text = text;
        audioSource.clip = audio;
        audioSource.Play();
        StartCoroutine(deleteText(time, blocking));
    }

    private IEnumerator deleteText(float time, bool blocking) {
        status.blockMovement = blocking;
        yield return new WaitForSeconds(time);
        message.text = null;
        status.blockMovement = false;
        yield break;
    }
}

