using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shotSpawn;
    public float fireRate;
    public float shakeDur;

    private float nextFire;
    public Animator animator;
    private AudioSource audio;
    private CameraFollow shake;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponentInParent<AudioSource>();
        shake = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
      if(!GameManager.playerCanMove)return;
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            animator.SetBool("Shooting", true);
            nextFire = Time.time + fireRate;
            Shoot();
            Sound s = SFXManager.instance.GetSFX("playerShoot");
            audio.clip = s.clips[0];
            audio.pitch = Random.Range(s.pitchMin, s.pitchMax);
            audio.volume = Random.Range(s.volumeMin, s.volumeMax);
            audio.Play();
            shake.shakeDuration = shakeDur;
        }
    }
    void Shoot()
    {
        GameObject shot = ShotPooler.instance.GetPlayerShot();

        if (shot != null)
        {
            shot.transform.position = this.shotSpawn.position;
            Vector3 eulerAngles = shotSpawn.rotation.eulerAngles;
            eulerAngles.x=0;
            eulerAngles.z=0;
            shot.transform.rotation = Quaternion.Euler(eulerAngles);
            shot.SetActive(true);
        }
    }
}
