using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner
{
    private SO_SpawnerData _spawnerData;
    private Transform _spawnPoint;
    private List<GameObject> _spawnedPrefabs = new List<GameObject>();
    private int _remainingEnemiesInWave;

    public Spawner(SO_SpawnerData spawnerData, Transform spawnPoint)
    {
        _spawnerData = spawnerData;
        _spawnPoint = spawnPoint;
    }

    internal IEnumerator SpawnEntitiesWithDelay(bool forceObjectToSpawn, GameObject forcedObject, bool usingWaves)
    {
        yield return new WaitForSeconds(_spawnerData.GetFirstSpawnDelay);

        if (usingWaves && !forceObjectToSpawn)
        {
            yield return SpawnWaves();
        }
        else if (forceObjectToSpawn)
        {
            yield return SpawnObjects(forcedObject);
        }
    }

    private IEnumerator SpawnWaves()
    {
        foreach (var wave in _spawnerData.Waves)
        {
            _remainingEnemiesInWave = wave.EnemiesInWave.Count;  // Set the remaining enemies for the wave

            foreach (var enemyPrefab in wave.EnemiesInWave)
            {
                InstantiatePrefab(enemyPrefab);
                yield return new WaitForSeconds(wave.SpawnDelayBetweenEnemies);
            }

            // Wait until all enemies in the wave are defeated
            yield return new WaitUntil(() => _remainingEnemiesInWave <= 0);

            // Wait before spawning the next wave
            yield return new WaitForSeconds(_spawnerData.GetNewSpawnDelay);
        }
    }

    private IEnumerator SpawnObjects(GameObject prefab)
    {
        for (int i = 0; i < _spawnerData.GetNumberOfPrefabsToCreate; i++)
        {
            InstantiatePrefab(prefab);
            yield return new WaitForSeconds(_spawnerData.GetNewSpawnDelay);
        }
    }

    private void InstantiatePrefab(GameObject prefab)
    {
        if (prefab == null) return;

        // Instantiate the prefab at the spawn point with a random offset
        var instance = GameObject.Instantiate(prefab, _spawnPoint.position + GetRandomOffset(), Quaternion.identity);
        instance.SetActive(true);
        _spawnedPrefabs.Add(instance);

        // Subscribe to the death event of the enemy
        EnemyHealthManager healthManager = instance.GetComponent<EnemyHealthManager>();
        if (healthManager != null)
        {
            healthManager.OnEnemyDeath += CountEnemyDeath;
        }
    }

    private void CountEnemyDeath()
    {
        _remainingEnemiesInWave--;  // Decrease the count of remaining enemies in the current wave
    }

    private Vector3 GetRandomOffset()
    {
        return new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
    }
}
