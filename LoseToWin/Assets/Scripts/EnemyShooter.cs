using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Fire", delay, fireRate);

    }
    void Fire()
    {
        GameObject shot = ShotPooler.instance.GetEnemyShot();

        if (shot != null)
        {
            shot.transform.position = this.shotSpawn.position;
            shot.transform.rotation = shotSpawn.rotation;
            shot.SetActive(true);
        }
    }
}
