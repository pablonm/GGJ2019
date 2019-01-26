using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour
{

    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public Vector3 offset;
    Vector3 targetPos;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GlobalSettings.cameraTarget)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = GlobalSettings.cameraTarget.transform.position.z;

            Vector3 targetDirection = (GlobalSettings.cameraTarget.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

        }
    }
}