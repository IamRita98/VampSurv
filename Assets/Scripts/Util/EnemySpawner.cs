using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    GameObject gManageGO;
    GetScreenSize getScreenSize;

    public GameObject enemy;

    public float spawnRadius = 15;
    public float buffer = 2f;
    public int enemiesToSpawn = 20;

    float minXSpawnRange;
    float minYSpawnRange;

    public bool spawnEnemies = false;

    float randomX;
    float randomY;
    Vector2 spawnLocation;


    private void Start()
    {
        gManageGO = GameObject.FindGameObjectWithTag("GameManager");
        getScreenSize = gManageGO.GetComponent<GetScreenSize>();

        minXSpawnRange = (getScreenSize.screenWidth / 2) + buffer;
        minYSpawnRange = (getScreenSize.screenHeight / 2) + buffer;
    }

    private void Update()
    {
        //probably going to set up a signal in a WaveManagement script to call this
        if (spawnEnemies)
        {
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int spawnQuad = Random.Range(0, 4); //0 is top, 1 right, 2 down, 3 left
            randomX = Random.Range(-spawnRadius, spawnRadius);
            randomY = Random.Range(-spawnRadius, spawnRadius);

            switch (spawnQuad)
            {
                case 0:
                    spawnLocation = new Vector2(randomX, minYSpawnRange);
                    break;
                case 1:
                    spawnLocation = new Vector2(minXSpawnRange, randomY);
                    break;
                case 2:
                    spawnLocation = new Vector2(randomX, -minYSpawnRange);
                    break;
                case 3:
                    spawnLocation = new Vector2(-minXSpawnRange, randomY);
                    break;
            }
            Instantiate(enemy, new Vector2(transform.position.x, transform.position.y) + spawnLocation, Quaternion.identity);
        }
        spawnEnemies = false;
    }
}
