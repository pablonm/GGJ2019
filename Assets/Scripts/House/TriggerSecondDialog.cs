using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSecondDialog : MonoBehaviour
{
    public string dialogText1;
    public AudioClip dialogAudio1;
    public float dialogTime1;
    public string dialogText2;
    public AudioClip dialogAudio2;
    public float dialogTime2;
    public bool blocking;

    private BGMController bgm;
    private bool triggered = false;

    private void Start()
    {
        bgm = FindObjectOfType<BGMController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            if (!triggered) {
                StartCoroutine(ShowDialogs(collision.gameObject.GetComponent<DialogController>()));
                triggered = true;
                bgm.PlayClips(new List<PlayClipInfo>() { new PlayClipInfo("desolacion", true) });
            }
        }
    }

    private IEnumerator ShowDialogs(DialogController controller) {
        controller.ShowDialog(dialogText1, dialogAudio1, dialogTime1, blocking);
        yield return new WaitForSeconds(dialogTime1);
        controller.ShowDialog(dialogText2, dialogAudio2, dialogTime2, blocking);
        yield break;
    }
}
