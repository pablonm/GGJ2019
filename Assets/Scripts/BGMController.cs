using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    public float fadeTime = 1;

    private Dictionary<string, AudioClip> clips;

    public void PlayClips(List<PlayClipInfo> playClips) {
        StopAllSources();
        playClips.ForEach((PlayClipInfo playClipInfo) =>
        {
            AudioSource source = transform.Find(playClipInfo.clip).GetComponent<AudioSource>();
            if (playClipInfo.active)
                StartCoroutine(FadeIn(source));
        });
    }

    private void StopAllSources() {
        foreach (Transform child in transform) {
            StartCoroutine(FadeOut(child.GetComponent<AudioSource>(), true));
        }
    }

    private IEnumerator FadeIn(AudioSource source) {
        if (source.volume < 1f) {
            source.volume = 0f;
            source.time = 0f;
            while (source.volume < 1.0f)
            {
                source.volume += 1f * Time.deltaTime / fadeTime;
                yield return null;
            }
        }
        yield break;
    }

    private IEnumerator FadeOut(AudioSource source, bool remove)
    {
        if (source.volume > 0) {
            while (source.volume > 0f)
            {
                source.volume -= 1f * Time.deltaTime / fadeTime * 2;
                yield return null;
            }
        }
        yield break;
    }

    public void ActivateTrack(string track) {
        StartCoroutine(FadeIn(transform.Find(track).GetComponent<AudioSource>()));
    }

    public void DeactivateTrack(string track)
    {
        StartCoroutine(FadeOut(transform.Find(track).GetComponent<AudioSource>(), false));
    }

}

public class PlayClipInfo {
    public string clip;
    public bool active;

    public PlayClipInfo(string c, bool a) {
        clip = c;
        active = a;
    }
}
