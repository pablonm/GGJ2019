using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    public float fadeTime = 1;

    private Dictionary<string, AudioClip> clips;
    private List<AudioSource> sources;

    private void Start()
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
        sources.ForEach((AudioSource s) =>
        {
            StartCoroutine(FadeOut(s, true));
        });
    }

    private IEnumerator FadeIn(AudioSource source) {
        source.volume = 0f;
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
        StartCoroutine(FadeIn(sources[track - 1]));
    }

    public void DeactivateTrack(int track)
    {
        StartCoroutine(FadeOut(sources[track - 1], false));
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            PlayClips(new List<PlayClipInfo>() { new PlayClipInfo("exploracion", true), new PlayClipInfo("batalla", false) });
        }
        if (Input.GetKeyUp(KeyCode.W)) {
            ActivateTrack(2);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            DeactivateTrack(2);
        }
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
