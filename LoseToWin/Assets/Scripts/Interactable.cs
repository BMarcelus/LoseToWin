using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Dialogue dialogue;
    private DialogueManager dialogueManager;
    private Quaternion targetAngle;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GameObject.FindObjectOfType<DialogueManager>();
        targetAngle = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetAngle, 0.2f);
    }

    void OnTriggerEnter(Collider col) {
      if(col.tag == "Player") {
        string text = dialogue.GetRandom();
        dialogueManager.ShowDialogue(text);
        targetAngle = Quaternion.LookRotation(col.transform.position-transform.position, Vector3.up);
      }
    }
    void OnTriggerExit(Collider col) {
      if(col.tag == "Player") {
        dialogueManager.CloseDialogue();
      }
    }
}
