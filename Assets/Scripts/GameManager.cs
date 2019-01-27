using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerStatus playerStatus;
    private DialogController dialogs;
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
        dialogs.ShowDialog("¡Yanka! ¿Donde estas?", null, 4, true);
    }
}
