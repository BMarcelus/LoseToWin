using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPooler : MonoBehaviour
{
    //This is what we're pooling
    public GameObject playerShotPrefab;
    public GameObject enemyShotPrefab;

    //Array that keeps track of what we have in our pool
    public List<GameObject> playerShots;

    public List<GameObject> enemyShots;

    //Number of things we want pooled
    public int amountToPoolPlayer;

    public int amountToPoolEnemy;

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
        playerShots = new List<GameObject>();
        for (int i = 0; i < amountToPoolPlayer; i++)
        {
            GameObject shot = (GameObject)Instantiate(playerShotPrefab);
            shot.SetActive(false);
            playerShots.Add(shot);
        }
        enemyShots = new List<GameObject>();
        for (int i = 0; i < amountToPoolEnemy; i++)
        {
            GameObject shot = (GameObject)Instantiate(enemyShotPrefab);
            shot.SetActive(false);
            enemyShots.Add(shot);
        }
    }
    public GameObject GetPlayerShot()
    {
        for(int i = 0; i < playerShots.Count; i++)
        {
            //check if shot is currently not active in the screen
            if (!playerShots[i].activeInHierarchy)
            {
                return playerShots[i];
            }
        }
        //Debug.Log("No Shots available");
        //unable to find available shot
        return null;
    }
}
