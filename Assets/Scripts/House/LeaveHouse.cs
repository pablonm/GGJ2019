using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveHouse : ActionableObject
{
    public SpriteRenderer sprite;
    private Rigidbody2D rb;
    private BGMController bgm;

    private void Start()
    {
        sprite.gameObject.SetActive(false);
        rb = FindObjectOfType<PlayerStatus>().GetComponent<Rigidbody2D>();
        bgm = FindObjectOfType<BGMController>();
    }

    protected override void Action()
    {
        
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<AudioSource>().Play();
        MapTransition.GoTo("Map", "SpawnFromHouse", 2f, Vector3.zero);
        StartCoroutine(PlaySong());
    }

    private IEnumerator PlaySong() {
        bgm.PlayClips(new List<PlayClipInfo>() { new PlayClipInfo("exploracion intro", true) });
        yield return new WaitForSeconds(10f);
        bgm.PlayClips(new List<PlayClipInfo>() { new PlayClipInfo("exploracion", true), new PlayClipInfo("batalla", false) });
        yield break;
    }

    protected override void OnEnter()
    {
        sprite.gameObject.SetActive(true);
    }

    protected override void OnExit()
    {
        sprite.gameObject.SetActive(false);
    }
}
