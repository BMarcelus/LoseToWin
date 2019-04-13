﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shotSpawn;
    public float fireRate;
    public bool isPlayer;

    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject shot = null;
        if (isPlayer)
        {
            shot = ShotPooler.instance.GetPlayerShot();
        }
        else
        {
            //GameObject shot = ShotPooler.instance.();
        }

        if (shot != null)
        {
            shot.transform.position = this.shotSpawn.position;
            shot.transform.rotation = shotSpawn.rotation;
            shot.SetActive(true);
        }
    }
}
