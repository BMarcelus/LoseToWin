﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CitizenManager : MonoBehaviour
{
    public GameObject player;
    private HealthManager health;
    private bool dying = false;
    private DialogueManager dialogueManager;
    /*
    A citizen has
      a gameobject in the world
      a model
      dialogue

    On death,
    Select citizen, move player to citizen
    change player model to citizen
    remove citizen
     */
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.Find("Player");
      health = player.GetComponent<HealthManager>();
      dialogueManager = GameObject.FindObjectOfType<DialogueManager>();
    }

    IEnumerator Respawn() {
      player.SetActive(false);
      yield return new WaitForSeconds(0.1f);
      dialogueManager.ShowDialogue("You are dead. But the fight continues");
      yield return new WaitForSeconds(1);
      player.SetActive(true);
      respawn();      
      dying = false;
    }

    public void respawn() {
      GameObject citizen = GetRandomCitizen();
      GameObject model = citizen.GetComponent<Interactable>().model;
      Vector3 pos = citizen.transform.position;
      pos.y=player.transform.position.y;
      player.transform.position = pos;
      player.transform.rotation = citizen.transform.rotation;
      player.GetComponent<ModelManager>().SetModel(model);
      Destroy(citizen);
      health.currentHealth = health.maximumHealth;
    }

    public GameObject GetRandomCitizen() {
      return transform.GetChild(Random.Range(0,transform.childCount)).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
      if(health.currentHealth<=0 && !dying) {
        dying = true;
        if(transform.childCount==0) {
          StartCoroutine(GameOver());
        } else {
          StartCoroutine(Respawn());
        }
      }
    }

    IEnumerator GameOver() {
      player.SetActive(false);
      yield return new WaitForSeconds(1f);
      dialogueManager.ShowDialogue("Every citizen has died. You have lost. Word of your revolution has reached across the world. Society moves towards positive change. You have won");
      while(dialogueManager.showingDialogue) {
        yield return new WaitForFixedUpdate();
      }
      SceneManager.LoadScene("BeginningScene");
    }
}
