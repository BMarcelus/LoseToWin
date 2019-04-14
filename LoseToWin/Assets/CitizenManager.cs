using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenManager : MonoBehaviour
{
    public GameObject player;
    private HealthManager health;
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
    }

    public void respawn() {
      GameObject citizen = GetRandomCitizen();
      GameObject model = citizen.GetComponent<Interactable>().model;
      player.transform.position = citizen.transform.position;
      player.transform.rotation = citizen.transform.rotation;
      player.GetComponent<ModelManager>().SetModel(model);
      Destroy(citizen);
      health.currentHealth = health.maximumHealth;
    }

    public GameObject GetRandomCitizen() {
      Debug.Log(transform.childCount);
      return transform.GetChild(Random.Range(0,transform.childCount)).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
      if(health.currentHealth<=0) {
        respawn();
      }
    }
}
