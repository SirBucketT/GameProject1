using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private SO_SpawnerData _spawnerData;
    [SerializeField] private Transform _spawnPoint;
    private List<GameObject> _spawnedPrefabs = new List<GameObject>();
    private int _remainingObjectsInWave;

    public void Initialize(SO_SpawnerData spawnerData, Transform spawnPoint)
    {
        _spawnerData = spawnerData;
        _spawnPoint = spawnPoint;
    }

    public IEnumerator SpawnEntitiesWithDelay(bool forceObjectToSpawn, GameObject forcedObject, bool usingWaves)
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
            _remainingObjectsInWave = wave.ObjectsInWave.Count;

            foreach (var objectPrefab in wave.ObjectsInWave)
            {
                if (objectPrefab == null) continue;

                if (_spawnerData.HasSpawnLimit && _spawnedPrefabs.Count >= _spawnerData.GetSpawnLimit)
                {
                    DespawnOldestObject();
                }

                InstantiatePrefab(objectPrefab);
                yield return new WaitForSeconds(wave.SpawnDelayBetweenObjects);
            }

            yield return new WaitUntil(() => _remainingObjectsInWave <= 0);
            yield return new WaitForSeconds(_spawnerData.GetNewSpawnDelay);
        }

        if (_spawnerData.GetIsLooping)
        {
            yield return SpawnEntitiesWithDelay(false, null, true);
        }
    }

    private IEnumerator SpawnObjects(GameObject prefab)
    {
        int objectsSpawned = 0;
        int limit = _spawnerData.HasSpawnLimit ? Mathf.FloorToInt(_spawnerData.GetSpawnLimit) : int.MaxValue;

        for (int i = 0; i < limit; i++)
        {
            if (objectsSpawned >= limit) break;

            if (_spawnerData.HasSpawnLimit && _spawnedPrefabs.Count >= _spawnerData.GetSpawnLimit)
            {
                DespawnOldestObject();
            }

            InstantiatePrefab(prefab);
            objectsSpawned++;
            yield return new WaitForSeconds(_spawnerData.GetNewSpawnDelay);
        }
    }

    private void InstantiatePrefab(GameObject prefab)
    {
        if (prefab == null) return;

        var instance = Instantiate(prefab, _spawnPoint.position + GetRandomOffset(), Quaternion.identity);
        instance.SetActive(true);

        _spawnedPrefabs.Add(instance);

        if (_spawnerData.GetDespawnOldestOnLimit && _spawnedPrefabs.Count > _spawnerData.GetSpawnLimit)
        {
            DespawnOldestObject();
        }

        EnemyHealthManager healthManager = instance.GetComponent<EnemyHealthManager>();
        if (healthManager != null)
        {
            healthManager.OnEnemyDeath += CountObjectDeath;
        }
    }

    private void DespawnOldestObject()
    {
        if (_spawnedPrefabs.Count == 0) return;

        GameObject oldestObject = _spawnedPrefabs[0];
        _spawnedPrefabs.RemoveAt(0);
        Destroy(oldestObject);
    }

    private void CountObjectDeath()
    {
        _remainingObjectsInWave--;
    }

    private Vector3 GetRandomOffset()
    {
        return new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
    }
}
