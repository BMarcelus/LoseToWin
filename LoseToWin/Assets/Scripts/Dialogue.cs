using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
  public string[] texts;
  public string GetRandom() {
    return texts[Random.Range(0,texts.Length)];
  }
}
