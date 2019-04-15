using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthManager : MonoBehaviour
{
    public GameObject ragdoll;
    public float maximumHealth = 3;
    public float currentHealth;
    public bool isPlayer = false;
    public float shakeDur;

    private AudioSource audio;
    private CameraFollow shake;

    private void Start()
    {
        currentHealth = maximumHealth;
        audio = GetComponent<AudioSource>();
        shake = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
    }

    public void reduceHealth()
    {
        currentHealth--;
        if (currentHealth == 0 && !isPlayer) {
            Destroy(this.gameObject);
            if (CompareTag("Enemy"))
            {
                GameManager.instance.UpdateScore();   
            }
            GameObject doll = Instantiate(ragdoll, transform.position, transform.rotation*ragdoll.transform.rotation);
            Destroy(doll, 2f);
        }
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
                Sound s = SFXManager.instance.GetSFX("enemyHurt");
                audio.clip = s.clips[Random.Range(0, s.clips.Length)];
                audio.pitch = Random.Range(s.pitchMin, s.pitchMax);
                audio.Play();
            }
            else if (!b.isPlayer && this.CompareTag("Player"))
            {
                reduceHealth();
                b.DisableBullet();
                Sound s = SFXManager.instance.GetSFX("playerHurt");
                audio.clip = s.clips[0];
                audio.pitch = Random.Range(s.pitchMin, s.pitchMax);
                audio.Play();
                shake.shakeDuration = shakeDur;
            }
        }
    }
    //write a function here to get the normalized health
    public float GetNormalizedHealth()
    {

        return currentHealth / maximumHealth;
    }
}
