using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<enemySpawnSettings> spawnConfigurations;
    public Transform[] spawnPoints;


    private int currentConfigurationIndex = 0;
    public float elapsedTime = 0f;
    private bool spawning = false;

    void Start()
    {
        if (spawnConfigurations.Count > 0)
        {
            StartCoroutine(SpawnEnemies());
        }
    }

    IEnumerator SpawnEnemies()
    {
        spawning = true;
        while (currentConfigurationIndex < spawnConfigurations.Count)
        {
            enemySpawnSettings currentSettings = spawnConfigurations[currentConfigurationIndex];
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= currentSettings.duration)
            {
                elapsedTime = 0f;
                currentConfigurationIndex++;
                continue;
            }

            yield return new WaitForSeconds(currentSettings.spawnRate);
            SpawnEnemy(currentSettings.enemyPrefab);
        }
        spawning = false;
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        if (spawnPoints.Length == 0) return;

        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    [System.Serializable]
    public class enemySpawnSettings
    {
        public GameObject enemyPrefab;
        public float spawnRate;
        public float duration;
    }
}
