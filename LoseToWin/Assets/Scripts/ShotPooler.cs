using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPooler : MonoBehaviour
{
    //This is what we're pooling
    public GameObject shotPrefab;
    //Array that keeps track of what we have in our pool
    public List<GameObject> shots;
    //Number of things we want pooled
    public int amountToPool;

    public static ShotPooler instance;

    private void Awake()
    {
        //Start singleton creation
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        //End singleton creation
    }

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate pool
        shots = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject shot = (GameObject)Instantiate(shotPrefab);
            shot.SetActive(false);
            shots.Add(shot);
        }
    }
    public GameObject GetShot()
    {
        for(int i = 0; i < shots.Count; i++)
        {
            //check if shot is currently not active in the screen
            if (!shots[i].activeInHierarchy)
            {
                return shots[i];
            }
        }
        //Debug.Log("No Shots available");
        //unable to find available shot
        return null;
    }
}
