using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _spawnedPrefab;
    [SerializeField] private int _numberOfEnemiesToCreate;
    [SerializeField] private bool _usingProximity;
    [SerializeField] float _firstSpawnDelay = 1f;
    [SerializeField] float _newSpawnDelay = 1f;
    [SerializeField] bool _isSpawnLimitOn;
    [SerializeField] private bool _despawnOldestOnLimit;
    [SerializeField] float _enemyLimit;
    [SerializeField] float _despawnDelay = 1f;
    private bool hasSpawned = false;
    
    private ProximityChecker _proximityChecker;
    private List<GameObject> _spawnedEnemies = new List<GameObject>();
    
    private void Start()
    {
        _proximityChecker = GetComponentInChildren<ProximityChecker>();
        if (!_usingProximity)
        {
            StartCoroutine(SpawnEntitiesWithDelay());
        }
    }
    
    private void Update()
    {
        if (_usingProximity && _proximityChecker.TargetIsWithinRange && !hasSpawned)
        {
            hasSpawned = true;
            StartCoroutine(SpawnEntitiesWithDelay());
        }
    }

    private GameObject EnemyInstantiate()
    {
        GameObject enemy = Instantiate(_spawnedPrefab, transform.position, Quaternion.identity);
        enemy.SetActive(true);
        return enemy;
    }

    private IEnumerator SpawnEntitiesWithDelay()
    {
        yield return new WaitForSeconds(_firstSpawnDelay);
        
        for (int i = 0; i < _numberOfEnemiesToCreate; i++)
        {
            GameObject enemy = EnemyInstantiate();
            _spawnedEnemies.Add(enemy);

            if (_isSpawnLimitOn && _spawnedEnemies.Count >= _enemyLimit)
            {
                CheckDespawnEnemies();
            }

            yield return new WaitForSeconds(_newSpawnDelay);
        }
    }

    private void CheckDespawnEnemies()
    {
        if (_despawnOldestOnLimit)
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
                yield return new WaitForSeconds(_despawnDelay);
                enemy.SetActive(false);
                Destroy(enemy);
            }
        }
        _spawnedEnemies.Clear();
    }
    private IEnumerator DespawnEnemy(GameObject enemy)
    {
        yield return new WaitForSeconds(_despawnDelay);
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
