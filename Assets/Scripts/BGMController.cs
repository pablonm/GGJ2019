using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    public float fadeTime = 1;

    private Dictionary<string, AudioClip> clips;
    private List<AudioSource> sources;

    private void Awake()
    {
        sources = new List<AudioSource>();
    }

    public void PlayClips(List<PlayClipInfo> playClips) {
        StopAllSources();
        playClips.ForEach((PlayClipInfo playClipInfo) =>
        {
            AudioSource source = transform.Find(playClipInfo.clip).GetComponent<AudioSource>();
            sources.Add(source);
            if (playClipInfo.active)
                StartCoroutine(FadeIn(source));
        });
    }

    private void StopAllSources() {
        if (sources.Count > 0) {
            sources.ForEach((AudioSource s) =>
            {
                StartCoroutine(FadeOut(s, true));
            });
        }
    }

    private IEnumerator FadeIn(AudioSource source) {
        source.volume = 0f;
        source.time = 0f;
        while (source.volume < 1.0f)
        {
            source.volume += 1f * Time.deltaTime / fadeTime;
            yield return null;
        }
        yield break;
    }

    private IEnumerator FadeOut(AudioSource source, bool remove)
    {
        while (source.volume > 0f)
        {
            source.volume -= 1f * Time.deltaTime / fadeTime;
            yield return null;
        }
        if (remove)
            sources.Remove(source);
        yield break;
    }

    public void ActivateTrack(int track) {
        if (sources[track - 1].volume == 0)
            StartCoroutine(FadeIn(sources[track - 1]));
    }

    public void DeactivateTrack(int track)
    {
        if (sources[track - 1].volume == 1)
            StartCoroutine(FadeOut(sources[track - 1], false));
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
