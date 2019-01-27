using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstepSounds : MonoBehaviour
{
    public List<AudioClip> clips;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayRandomClip() {
        source.clip = clips[Random.Range(0, clips.Count)];
        source.Play();
    }
}
