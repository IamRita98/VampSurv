using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    GameObject gManageGO;
    GetScreenSize getScreenSize;
    GameObject enemyHolder;


    public float spawnRadius = 15;
    public float buffer = 2f;

    float minXSpawnRange;
    float minYSpawnRange;

    float randomX;
    float randomY;
    Vector2 spawnLocation;


    private void Start()
    {
        gManageGO = GameObject.FindGameObjectWithTag("GameManager");
        getScreenSize = gManageGO.GetComponent<GetScreenSize>();
        enemyHolder = GameObject.FindGameObjectWithTag("EnemyHolder");

        minXSpawnRange = (getScreenSize.screenWidth / 2) + buffer;
        minYSpawnRange = (getScreenSize.screenHeight / 2) + buffer;
    }

    private void OnEnable()
    {
        EnemyWaveManager.onWaveSpawned += SpawnEnemies;
    }

    private void OnDisable()
    {
        EnemyWaveManager.onWaveSpawned -= SpawnEnemies;
    }

    void SpawnEnemies(List<GameObject> spawnTable, int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject enemyToSpawn = spawnTable[0];

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
            Instantiate(enemyToSpawn, new Vector2(transform.position.x, transform.position.y) + spawnLocation, Quaternion.identity, enemyHolder.transform);
            spawnTable.RemoveAt(0);
            spawnTable.Add(enemyToSpawn);
        }
    }
}
