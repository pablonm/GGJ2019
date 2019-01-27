using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioClip InitialDialogClip;
    public Transform cameraTarget;
    public float EnemyDebuff;
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

    internal static void PlayerDead()
    {
        throw new NotImplementedException();
    }

    private void Init() {

        /* Settings */
        GlobalSettings.betteryRate = 2f;
        GlobalSettings.vodkaRate = 20f;
        GlobalSettings.maxBattery = 8;
        GlobalSettings.cameraTarget = cameraTarget;
        GlobalSettings.EnemyDebuff = EnemyDebuff;

        /* Player status */
        playerStatus.transform.position = initialPlayerPosition;
        playerStatus.health = 100f;
        playerStatus.currentBatery = 100f;
        playerStatus.batteries = 0;
        playerStatus.stamina = 100f;
        playerStatus.blockMovement = false;
        playerStatus.running = false;
        playerStatus.recharging = false;
        playerStatus.usingFlashlight = false;
        playerStatus.grabbingChild = false;

        bgm.PlayClips(new List<PlayClipInfo>() { new PlayClipInfo("calma", true) });
        Camera.main.transform.position = new Vector3(initialPlayerPosition.x, initialPlayerPosition.y, Camera.main.transform.position.z);
        StartCoroutine(initDialog());
    }

    private IEnumerator initDialog() {
        yield return new WaitForSeconds(1f);
        dialogs.ShowDialog("¡Svetla! ¿Donde estas?", InitialDialogClip, 4, true);
        yield break;
    }

}
