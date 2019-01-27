using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSFXList : MonoBehaviour
{
    public List<AudioClip> clips;
    public Vector2 silences;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(PlayClips());
    }

    private IEnumerator PlayClips() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(silences.x, silences.y));
            source.clip = clips[Random.Range(0, clips.Count - 1)];
            source.Play();
        }
    }
}
