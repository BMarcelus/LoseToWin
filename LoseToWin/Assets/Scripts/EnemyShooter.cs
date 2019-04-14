using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    public Animator animator;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
      player = GameManager.player;
        InvokeRepeating("Fire", delay, fireRate);

    }
    void Fire()
    {
      Vector3 diff = player.transform.position - transform.position;
      if(diff.magnitude>30)return;
        GameObject shot = ShotPooler.instance.GetEnemyShot();

        if (shot != null)
        {
            shot.transform.position = this.shotSpawn.position;
            shot.transform.rotation = shotSpawn.rotation;
            shot.SetActive(true);
            animator.SetBool("Shooting", true);
        }
    }
}
