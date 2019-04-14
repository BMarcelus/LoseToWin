using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    public static GameObject player;
    public static bool playerCanMove = true;

    public int score;
    public PointUI points;

    // Start is called before the first frame update
    void Start()
    {
        //Singleton but not really
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        score = 0;
    }
    public void UpdateScore()
    {
        score+=10;
        points.UpdatePointText();
    }
}
