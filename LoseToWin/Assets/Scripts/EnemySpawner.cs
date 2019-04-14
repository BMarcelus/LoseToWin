using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnLocs;
    public GameObject enemyPrefab;

    public float spawnRate;
    public bool spawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawn)
            StopCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            //pick spawnLoc
            if (spawnLocs.Length != 0)
            {
                Transform spawnLoc = spawnLocs[Random.Range(0, spawnLocs.Length)];
                //ensure correct y
                spawnLoc.position.Set(spawnLoc.position.x, spawnLoc.position.y, spawnLoc.position.z);
                Instantiate(enemyPrefab, spawnLoc.position, spawnLoc.rotation);
                yield return new WaitForSeconds(spawnRate);
            }
        }
    }
}
