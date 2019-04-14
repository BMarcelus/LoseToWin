using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    private GameObject player;
    public Animator animator;
    private AudioSource audio;
    // Use this for initialization
    void Start()
    {
        audio = GetComponentInParent<AudioSource>();
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
            Sound s = SFXManager.instance.GetSFX("playerShoot");
            audio.clip = s.clips[0];
            audio.pitch = Random.Range(s.pitchMin, s.pitchMax);
            audio.volume = Random.Range(s.volumeMin, s.volumeMax);
            audio.Play();
        }
    }
}
