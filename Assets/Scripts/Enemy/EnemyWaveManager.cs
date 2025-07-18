using UnityEngine;
using System.Collections.Generic;

public class EnemyWaveManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject tankyEnemy;
    public int enemiesToSpawn;
    
    Timer timer;
    public float timeToSpawnWave;

    public List<GameObject> spawnTable = new List<GameObject>();

    public static event System.Action<List<GameObject>, int> onWaveSpawned;

    private void Start()
    {
        timer = GetComponent<Timer>();

        SetSpawnTable();
        SpawnWave();
    }

    private void Update()
    {
        if (timer.timerComplete)
        {
            timer.timerComplete = false;
            SpawnWave();
            
        }
    }

    void SetSpawnTable()
    {
        //More Complex behaviour to come. This is filler. Prob base it off of a global timer that's counting up for game duration
        spawnTable.Add(enemy);
        spawnTable.Add(enemy);
        spawnTable.Add(enemy);
        spawnTable.Add(tankyEnemy);
    }

    void SpawnWave()
    {
        timer.SetTimer(timeToSpawnWave);
        onWaveSpawned?.Invoke(spawnTable, enemiesToSpawn);
    }
}
