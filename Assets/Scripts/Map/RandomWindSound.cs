using System.Collections;
using UnityEngine;

public class RandomWindSound : MonoBehaviour
{
    public float fadeTime = 1;
    public Vector2 duration;
    public Vector2 silences;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(PlayWind());
    }

    private IEnumerator FadeIn()
    {
        source.time = 0f;
        while (source.volume < 1f)
        {
            source.volume += 1f * Time.deltaTime / fadeTime;
            yield return null;
        }
        yield break;
    }

    private IEnumerator FadeOut()
    {
        while (source.volume > 0f)
        {
            source.volume -= 1f * Time.deltaTime / fadeTime;
            yield return null;
        }
        yield break;
    }

    private IEnumerator PlayWind() {
        while (true) {
            StartCoroutine(FadeIn());
            yield return new WaitForSeconds(Random.Range(duration.x, duration.y));
            StartCoroutine(FadeOut());
            yield return new WaitForSeconds(Random.Range(silences.x, silences.y));
        }
    }
}
