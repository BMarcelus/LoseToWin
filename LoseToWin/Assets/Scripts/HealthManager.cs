using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthManager : MonoBehaviour
{
    public int maximumHealth = 3;
    private int currentHealth;

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
            //if player's bullet and not the player
            if (b.isPlayer && !this.CompareTag("Player"))
            {
                reduceHealth();
            }
            b.DisableBullet();
        }
    }
}
