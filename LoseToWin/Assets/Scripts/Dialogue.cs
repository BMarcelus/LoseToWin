using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
  public string[] texts;
  private int index = 0;

  public string GetRandom() {
    string text = texts[index];
    index++;
    if(index>=texts.Length)index=0;
    return text;
    // return texts[Random.Range(0,texts.Length)];
  }

  public string GetIndex(int index) {
    return texts[index % texts.Length];
  }
}
