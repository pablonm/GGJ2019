using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerStatus playerStatus;
    private DialogController dialogs;
    public AudioClip InitialDialogClip;
    private BGMController bgm;
    private Vector3 initialPlayerPosition;

    private void Start()
    {
        playerStatus = FindObjectOfType<PlayerStatus>();
        bgm = FindObjectOfType<BGMController>();
        dialogs = FindObjectOfType<DialogController>();
        initialPlayerPosition = GameObject.Find("InitialPosition").transform.position;
        Init();
    }

    private void Init() {
        bgm.PlayClips(new List<PlayClipInfo>() { new PlayClipInfo("calma", true) });
        playerStatus.transform.position = initialPlayerPosition;
        Camera.main.transform.position = new Vector3(initialPlayerPosition.x, initialPlayerPosition.y, Camera.main.transform.position.z);
        StartCoroutine(initDialog());
    }

    private IEnumerator initDialog() {
        yield return new WaitForSeconds(1f);
        dialogs.ShowDialog("¡Svetla! ¿Donde estas?", InitialDialogClip, 4, true);
        yield break;
    }
}
