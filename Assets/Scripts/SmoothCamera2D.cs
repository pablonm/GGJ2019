using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class SmoothCamera2D : MonoBehaviour
{

    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public Vector3 offset;
    Vector3 targetPos;

    private bool blockTracking = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (GlobalSettings.cameraTarget && !blockTracking)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = GlobalSettings.cameraTarget.transform.position.z;

            Vector3 targetDirection = (GlobalSettings.cameraTarget.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

        }
    }

    public void FadeOutIn(UnityAction callback) {
        StartCoroutine(FadeOutInCoroutine(callback));
    }

    private IEnumerator FadeOutInCoroutine(UnityAction callback) {
        animator.SetTrigger("fadein");
        yield return new WaitForSeconds(1f);
        callback();
        animator.SetTrigger("fadeout");
        yield return new WaitForSeconds(1f);
        yield break;
    }
}