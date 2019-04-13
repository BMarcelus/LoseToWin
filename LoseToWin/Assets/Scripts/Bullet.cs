using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float speed;
    public float timeToLive;
    private float timeRemaining;
    private Rigidbody rb;
    private 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timeRemaining = timeToLive;
    }
    private void Update()
    {
        if(this.isActiveAndEnabled && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            this.gameObject.SetActive(false);
            timeRemaining = timeToLive;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
    }
}
