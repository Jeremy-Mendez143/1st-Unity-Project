using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave 
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups; //A list of groups of enemies to spawn in this wave
        public int waveQuota; //The number of total enemies to spawn
        public float spawnInterval; //The interval at which to spawn the enemies
        public int spawnCount; //The number of enemies already spawned
    }

    [System.Serializable]
    public class EnemyGroup {

        public string enemyName;
        public int enemiesToSpawn; //The number of enemies to spawn in this wave
        public int spawnCount; //The number of enemies this type already spawned this wave
        public GameObject prefab;
    }

    public List<Wave> waves;
    public int currentWaveCount;
    public int enemiesAlive;
    public int maxEnemies;
    public bool maxEnemiesReached;

    [Header("Spawner Attributes")]
    float spawnTimer; //Time to wait until spawn
    public float waveInterval; //The interval between each wave

    [Header("Spawn Positions")]
    public List<Transform> spawnPositions; 

    Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerStats>().transform;
        CalculateWaveQuota();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the wave has ended and the next wave should start
        if(currentWaveCount < waves.Count && waves[currentWaveCount].spawnCount == 0)
        {
            StartCoroutine(BeginNextWave());
        }

        //Continuously to spawn enemies until waveInterval elapsed
        spawnTimer += Time.deltaTime;

        if(spawnTimer > waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();
        }
    }

    IEnumerator BeginNextWave()
    {
        yield return new WaitForSeconds(waveInterval);

        // Increment current wave count
        currentWaveCount++;

        // If we have reached the end of the waves list, loop back to the first wave
        if (currentWaveCount >= waves.Count)
        {
            currentWaveCount = 0;
        }

        // Modify enemy attack for the current wave
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            // Example: Increase enemy attack by 10%
            EnemyStats enemyStats = enemyGroup.prefab.GetComponent<EnemyStats>();
            if (enemyStats != null)
            {
                enemyStats.currentDamage *= 1.1f; // Increase attack by 10%
            }
        }

        // Decrease spawn interval for the current wave

        if (waves[currentWaveCount].spawnInterval > 2)
        {
            waves[currentWaveCount].spawnInterval *= 0.8f; // Example: Decrease by 20%
        }

        // Reset spawn count for the current wave
        waves[currentWaveCount].spawnCount = 0;

        // Reset spawn count for each enemy group within the wave
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            enemyGroup.spawnCount = 0;
        }

        // Calculate the wave quota again for the current wave
        CalculateWaveQuota();

        // Start spawning enemies for the next wave
        maxEnemiesReached = false;
    }



    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;

        foreach(var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemiesToSpawn;
        }

        waves[currentWaveCount].waveQuota = currentWaveQuota;
        Debug.LogWarning(currentWaveQuota);
    }

    //This method will stop spawning enemies once the max number of enemies on the map is maxed.
    //The method will only spawn enemies in a particular wave until it is time for the next wave
    void SpawnEnemies()
    {
        //Check if the minimum number of enemies in the wave have been spawned
        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota && !maxEnemiesReached)
        {

            //Spawn each type of enemy until the quota is filled
            foreach(var enemyGroup in waves[currentWaveCount].enemyGroups)
            {

                //Check minimum number of enemies of this type have been spawned
                if(enemyGroup.spawnCount < enemyGroup.enemiesToSpawn)
                {
                    Instantiate(enemyGroup.prefab, player.transform.position + spawnPositions[Random.Range(0, spawnPositions.Count)].position, Quaternion.identity);

                    if(enemiesAlive >= maxEnemies)
                    {
                        maxEnemiesReached = true;
                        return;
                    }

                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;
                    enemiesAlive++;
                }
            }
        }

        //Reset
        if(enemiesAlive < maxEnemies)
        {
            maxEnemiesReached = false;
        }

    }

    public void OnEnemyKilled()
    {
        //Decrement
        enemiesAlive--;
    }

}
