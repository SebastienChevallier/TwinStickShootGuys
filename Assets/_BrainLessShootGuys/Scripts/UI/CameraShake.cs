using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform;

    public float shakeDuration = 0.1f;
    private float currentShakeDuration = 0f;

    public float shakeAmount = 5f;
    public float decreaseFactor = 1.0f;

    private Vector3 originalPos;

    void Awake()
    {
        if (cameraTransform == null)
        {
            cameraTransform = GetComponent(typeof(Transform)) as Transform;
        }
        originalPos = cameraTransform.localPosition;
    }

    public void ShakeCamera()
    {
        currentShakeDuration = shakeDuration;
        StartCoroutine(ShakeCameraCoroutine());
    }

    IEnumerator ShakeCameraCoroutine()
    {
        while (currentShakeDuration > 0)
        {
            cameraTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            currentShakeDuration -= Time.deltaTime * decreaseFactor;
            yield return new WaitForFixedUpdate();
        }

        currentShakeDuration = 0f;
        cameraTransform.localPosition = originalPos;
    }
}