using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PointUI : MonoBehaviour
{
    private Text pointText;
    // Start is called before the first frame update
    void Start()
    {
        pointText = GetComponent<Text>();
    }

    public void UpdatePointText()
    {
        pointText.text = "Revolution Points: " + GameManager.instance.score;
    }
}
