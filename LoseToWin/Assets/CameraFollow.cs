
using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform target;

    public float smoothSpeed = 0.125f;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    public Vector3 offset;
    public bool setOffsetOnStart;

    void Start() {
      target = GameObject.Find("Player").transform;
      if(setOffsetOnStart) {
        offset = transform.position - target.position;
      }
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothPosition;
            if(shakeDuration > 0)
            {
                transform.position = smoothPosition + Random.insideUnitSphere * shakeAmount;
                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
        }
    }
} 

