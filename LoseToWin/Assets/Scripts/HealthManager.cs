using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthManager : MonoBehaviour
{
    public int maximumHealth = 3;
    private int currentHealth;

    public void reduceHealth()
    {
        currentHealth--;
    }
}
