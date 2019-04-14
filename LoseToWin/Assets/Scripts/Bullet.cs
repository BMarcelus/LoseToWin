using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float speed;
    public float timeToLive;
    public bool isPlayer;

    private float timeRemaining;
    private Rigidbody rb;

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
            DisableBullet();
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
    }

    public void DisableBullet()
    {
        GetComponent<TrailRenderer>().Clear();
        this.gameObject.SetActive(false);
        timeRemaining = timeToLive;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player") && !other.CompareTag("Enemy"))
            DisableBullet();
    }
}
