using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSpawner : MonoBehaviour
{
    public GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider col) {
      if(col.tag == "Player") {
        spawner.SetActive(true);
        DialogueManager dialogue = GameObject.FindObjectOfType<DialogueManager>();
        dialogue.ShowDialogue("Attention Citizens, due to recent insubordination, this city will be overtaken to build a new freeway. Do not resist or you will lose.");
        Destroy(gameObject);
      }
    }
}
