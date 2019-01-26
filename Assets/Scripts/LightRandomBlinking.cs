using System.Collections;
using UnityEngine;

public class LightRandomBlinking : MonoBehaviour
{
    public Vector2 timeRange;
    private SpriteRenderer sprite;
    private Color originalColor;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        originalColor = sprite.color;
        StartCoroutine(Blink());
    }

    private IEnumerator Blink() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(timeRange.x, timeRange.y));
            Color newColor = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
            sprite.color = newColor;
            yield return new WaitForSeconds(0.05f);
            sprite.color = originalColor;
        }
    }
}
