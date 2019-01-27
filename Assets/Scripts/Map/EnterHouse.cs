using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouse : ActionableObject
{
    public GameObject childInHouse;

    private Rigidbody2D rb;
    private BGMController bgm;
    private PlayerStatus status;

    private void Start()
    {
        rb = FindObjectOfType<PlayerStatus>().GetComponent<Rigidbody2D>();
        bgm = FindObjectOfType<BGMController>();
        status = FindObjectOfType<PlayerStatus>();
    }

    protected override void Action()
    {
        if (status.grabbingChild)
        {
            bgm.PlayClips(new List<PlayClipInfo>() { new PlayClipInfo("calma", true) });
            status.blockMovement = true;
            childInHouse.SetActive(true);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
            MapTransition.GoTo("House", "SpawnFinalCinematic", 1.3f, new Vector3(0f, 0.065f, 0f));
            StartCoroutine(ShowFinalDialogs());
        }
        else
        {
            bgm.PlayClips(new List<PlayClipInfo>() { new PlayClipInfo("desolacion", true) });
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
            MapTransition.GoTo("House", "SpawnFromMap", 1.3f, new Vector3(0f, 0.065f, 0f));
        }
    }

    private IEnumerator ShowFinalDialogs() {
        childInHouse.GetComponent<DialogController>().ShowDialog("Gracias padre por traerme de vuelta a nuestro hogar", null, 4f, true);
        status.blockMovement = true;
        yield return new WaitForSeconds(4f);
        status.gameObject.GetComponent<DialogController>().ShowDialog("El hogar es cuando estamos juntos, Svetla", null, 6f, true);
        yield return new WaitForSeconds(4f);
        Camera.main.GetComponent<Animator>().SetTrigger("fadein");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Credits");
        status.blockMovement = true;
        yield break;
    }

    protected override void OnEnter() {}

    protected override void OnExit() {}
}
