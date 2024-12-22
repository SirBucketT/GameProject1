using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class SpawnerController : MonoBehaviour
{
    [SerializeField] private SO_SpawnerData _spawnerData;
    [SerializeField] private bool usingProximity;
    private bool hasSpawned = false;
    private ProximityChecker _proximityChecker;
    private List<GameObject> _spawnedPrefabs = new List<GameObject>();

    private Vector3 _spawnPositionOffset;

    private void Awake()
    {
        _spawnPositionOffset = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        );
    }

    private void Start()
    {
        _proximityChecker = GetComponentInChildren<ProximityChecker>();
        if (!usingProximity)
        {
            StartCoroutine(SpawnEntitiesWithDelay());
        }
    }

    private void Update()
    {
        if (usingProximity && _proximityChecker.TargetIsWithinRange && !hasSpawned)
        {
            hasSpawned = true;
            StartCoroutine(SpawnEntitiesWithDelay());
        }
    }

    private Vector3 GetRandomSpawnOffset()
    {
        return new Vector3(
            Random.Range(-1f, 1f),
            0f,
            Random.Range(-1f, 1f)
        );
    }

    private GameObject EnemyInstantiate()
    {
        Vector3 spawnPositionOffset = GetRandomSpawnOffset();
        GameObject enemy = Instantiate(_spawnerData.spawnedPrefab, transform.position + spawnPositionOffset, Quaternion.identity);
        enemy.SetActive(true);
        return enemy;
    }

    private IEnumerator SpawnEntitiesWithDelay()
    {
        yield return new WaitForSeconds(_spawnerData.firstSpawnDelay);

        for (int i = 0; i < _spawnerData.numberOfPrefabsToCreate; i++)
        {
            GameObject enemy = EnemyInstantiate();
            _spawnedPrefabs.Add(enemy);

            if (_spawnerData.isSpawnLimitOn && _spawnedPrefabs.Count >= _spawnerData.spawnLimit)
            {
                CheckDespawnEnemies();
            }

            yield return new WaitForSeconds(_spawnerData.newSpawnDelay);
        }
    }

    private void CheckDespawnEnemies()
    {
        if (_spawnerData.despawnOldestOnLimit)
        {
            StartCoroutine(DespawnOldestEnemy());
        }
        else
        {
            StartCoroutine(DespawnAllEnemies());
        }
    }

    private IEnumerator DespawnOldestEnemy()
    {
        if (_spawnedPrefabs.Count > 0)
        {
            GameObject oldestEnemy = _spawnedPrefabs[0];
            _spawnedPrefabs.RemoveAt(0);
            yield return DespawnEnemy(oldestEnemy);
        }
    }

    private IEnumerator DespawnAllEnemies()
    {
        foreach (var enemy in _spawnedPrefabs)
        {
            if (enemy != null)
            {
                yield return new WaitForSeconds(_spawnerData.despawnDelay);
                enemy.SetActive(false);
                Destroy(enemy);
            }
        }
        _spawnedPrefabs.Clear();
    }

    private IEnumerator DespawnEnemy(GameObject enemy)
    {
        yield return new WaitForSeconds(_spawnerData.despawnDelay);
        if (enemy != null)
        {
            enemy.SetActive(false);
            Destroy(enemy);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawCube(transform.position, Vector3.one);
    }
}
