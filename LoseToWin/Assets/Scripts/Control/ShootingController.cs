using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(!GameManager.playerCanMove)return;
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            animator.SetBool("Shooting", true);
            nextFire = Time.time + fireRate;
            GameObject s = Instantiate(bulletPrefab, shotSpawn.position, shotSpawn.rotation);
            Destroy(s, 2);
        }
    }
}
