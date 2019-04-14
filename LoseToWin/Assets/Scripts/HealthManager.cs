using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthManager : MonoBehaviour
{
    public GameObject ragdoll;
    public int maximumHealth = 3;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maximumHealth;
    }

    public void reduceHealth()
    {
        currentHealth--;
        if (currentHealth == 0) {
            Destroy(this.gameObject);
            Instantiate(ragdoll, transform.position, transform.rotation*ragdoll.transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Bullet>() != null)
        {
            Bullet b = other.gameObject.GetComponent<Bullet>();
            if (b.isPlayer && this.CompareTag("Enemy"))
            {
                reduceHealth();
                b.DisableBullet();
            }
            else if (!b.isPlayer && this.CompareTag("Player"))
            {
                reduceHealth();
                b.DisableBullet();
            }
            
        }
    }
}
