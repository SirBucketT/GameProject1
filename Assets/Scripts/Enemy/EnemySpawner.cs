using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SO_SpawnerData _spawnerData;
    private bool hasSpawned = false;
    private ProximityChecker _proximityChecker;
    private List<GameObject> _spawnedEnemies = new List<GameObject>();

    private void Start()
    {
        _proximityChecker = GetComponentInChildren<ProximityChecker>();
        if (!_spawnerData.usingProximity)
        {
            StartCoroutine(SpawnEntitiesWithDelay());
        }
    }

    private void Update()
    {
        if (_spawnerData.usingProximity && _proximityChecker.TargetIsWithinRange && !hasSpawned)
        {
            hasSpawned = true;
            StartCoroutine(SpawnEntitiesWithDelay());
        }
    }

    private GameObject EnemyInstantiate()
    {
        GameObject enemy = Instantiate(_spawnerData.spawnedPrefab, transform.position, Quaternion.identity);
        enemy.SetActive(true);
        return enemy;
    }

    private IEnumerator SpawnEntitiesWithDelay()
    {
        yield return new WaitForSeconds(_spawnerData.firstSpawnDelay);

        for (int i = 0; i < _spawnerData.numberOfEnemiesToCreate; i++)
        {
            GameObject enemy = EnemyInstantiate();
            _spawnedEnemies.Add(enemy);

            if (_spawnerData.isSpawnLimitOn && _spawnedEnemies.Count >= _spawnerData.enemyLimit)
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
        if (_spawnedEnemies.Count > 0)
        {
            GameObject oldestEnemy = _spawnedEnemies[0];
            _spawnedEnemies.RemoveAt(0);
            yield return DespawnEnemy(oldestEnemy);
        }
    }

    private IEnumerator DespawnAllEnemies()
    {
        foreach (var enemy in _spawnedEnemies)
        {
            if (enemy != null)
            {
                yield return new WaitForSeconds(_spawnerData.despawnDelay);
                enemy.SetActive(false);
                Destroy(enemy);
            }
        }
        _spawnedEnemies.Clear();
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
