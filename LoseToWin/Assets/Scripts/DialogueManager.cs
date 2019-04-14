using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public string text;
    public string displayText;
    public bool showingDialogue = false;
    private int characterIndex = 0;
    public float talkSpeed = .1f;
    private float talkTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void updateDisplayText() {
      displayText = text.Substring(0,characterIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if(showingDialogue) {
          bool crawling = characterIndex < text.Length;
          if(crawling) {
            if(talkTimer>0) {
              talkTimer -= Time.deltaTime;
            } else {
              talkTimer = talkSpeed;
              characterIndex += 1;
              updateDisplayText();
            }
          }
          if(Input.GetButtonDown("Jump")) {
            if(crawling) {
              characterIndex = text.Length;
              updateDisplayText();
            } else {
              CloseDialogue();
            }
          }
        }
    }

    public void CloseDialogue() {
      showingDialogue = false;
      // GameManager.playerCanMove = true;
    }

    public void ShowDialogue(string t) {
      if(showingDialogue)return;
      text = t;
      showingDialogue = true;
      characterIndex = 0;
      updateDisplayText();
      // GameManager.playerCanMove = false;
    }
    public string GetDialogue() {
      return displayText;
    }
}
