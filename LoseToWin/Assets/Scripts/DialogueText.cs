using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueText : MonoBehaviour
{
    private DialogueManager dialogueManager;
    public GameObject display;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GameObject.FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        display.SetActive(dialogueManager.showingDialogue);
        text.text = dialogueManager.GetDialogue();
    }
}
