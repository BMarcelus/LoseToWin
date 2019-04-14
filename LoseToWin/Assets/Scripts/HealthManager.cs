using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthManager : MonoBehaviour
{
    public float maximumHealth = 3;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maximumHealth;

    }

    public void reduceHealth()
    {
        currentHealth--;
        if (currentHealth == 0)
            Destroy(this.gameObject);
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
    //write a function here to get the normalized health
    public float GetNormalizedHealth()
    {
         
        return currentHealth / maximumHealth;
    }
}
