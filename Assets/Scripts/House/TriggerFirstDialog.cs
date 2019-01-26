using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFirstDialog : MonoBehaviour
{
    private BGMController bgm;
    private bool triggered = false;

    private void Start()
    {
        bgm = FindObjectOfType<BGMController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO trigger dialog
        if (!triggered) {
            triggered = true;
            bgm.PlayClips(new List<PlayClipInfo>() { new PlayClipInfo("desolacion", true) });
        }
    }
}
