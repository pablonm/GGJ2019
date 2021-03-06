﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class ActionableObject : MonoBehaviour
{
    public enum Buttons { A, LT }
    public Buttons button;
    public string message;
    public bool repeatable;
    protected bool done = false;

    private bool debouncing = false;
    private GameObject actionMessagePrefab;

    protected abstract void Action();
    protected abstract void OnEnter();
    protected abstract void OnExit();

    private void Awake()
    {
        LoadResources();
    }

    private void LoadResources() {
        actionMessagePrefab = Resources.Load<GameObject>("ActionMessage");
        Sprite buttonSprite = null;
        switch (button) {
            case Buttons.A:
                buttonSprite = Resources.Load<Sprite>("A");
                break;
            case Buttons.LT:
                buttonSprite = Resources.Load<Sprite>("LT");
                break;
        }
        actionMessagePrefab = Instantiate(actionMessagePrefab, transform);
        actionMessagePrefab.transform.Find("Message").GetComponent<Text>().text = message;
        actionMessagePrefab.transform.Find("Button").GetComponent<Image>().sprite = buttonSprite;
        actionMessagePrefab.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!debouncing && !done && Input.GetAxis("Action") > 0)
        {
            StartCoroutine(Debounce());
            if (!repeatable)
            {
                done = true;
                actionMessagePrefab.SetActive(false);
            }
            Action();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!done && collision.gameObject.CompareTag("Player"))
        {
            actionMessagePrefab.SetActive(true);
            OnEnter();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!done && collision.gameObject.CompareTag("Player"))
        {
            actionMessagePrefab.SetActive(false);
            OnExit();
        }
    }

    private IEnumerator Debounce() {
        debouncing = true;
        yield return new WaitForSeconds(1f);
        debouncing = false;
        yield break;
    }
}
