using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar; // Connect to the healthbar
    // Start is called before the first frame update
    void Start()
    {
    healthBar.SetSize(.4f);

    }
}
