using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class SpawnerController : MonoBehaviour
{
    [SerializeField] private SO_SpawnerData _spawnerData;
    [SerializeField] private GameObject _objectToSpawn;
    [SerializeField] private bool _usingProximity;
    [SerializeField] private bool _usingWaves;
    private bool _hasSpawned = false;
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
        if (_spawnerData == null)
        {
            Debug.LogError("SpawnerData is not assigned!");
            return;
        }

        CheckForProximity();
    }
    
    private void Update()
    {
        if (_usingProximity && _proximityChecker != null && _proximityChecker.TargetIsWithinRange && !_hasSpawned)
        {
            _hasSpawned = true;
            StartCoroutine(SpawnEntitiesWithDelay());
        }
    }

    private void CheckForProximity()
    {
        _proximityChecker = GetComponentInChildren<ProximityChecker>();
        if (_usingProximity && _proximityChecker == null)
        {
            Debug.LogWarning("ProximityChecker is required but not found!");
            return;
        }

        if (!_usingProximity)
        {
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

    private IEnumerator SpawnEntitiesWithDelay()
    {
        yield return new WaitForSeconds(_spawnerData.GetFirstSpawnDelay);

        if (_usingWaves)
        {
            yield return SpawnWaves();
        }
        else
        {
            yield return SpawnPrefabs();
        }

        if (IsSpawnLimitOn())
        {
            CheckDespawnEnemies();
        }
    }

    private IEnumerator SpawnWaves()
    {
        foreach (var wave in _spawnerData.Waves)
        {
            foreach (var enemyPrefab in wave.EnemiesInWave)
            {
                if (enemyPrefab != null)
                {
                    GameObject prefab = Instantiate(
                        enemyPrefab,
                        transform.position + GetRandomSpawnOffset(),
                        Quaternion.identity
                    );
                    prefab.SetActive(true);
                    _spawnedPrefabs.Add(prefab);
                }

                yield return new WaitForSeconds(wave.SpawnDelayBetweenEnemies);
            }

            yield return new WaitForSeconds(_spawnerData.GetNewSpawnDelay);
        }
    }

    private IEnumerator SpawnPrefabs()
    {
        for (int i = 0; i < _spawnerData.GetNumberOfPrefabsToCreate; i++)
        {
            if (_objectToSpawn != null)
            {
                GameObject prefab = Instantiate(
                    _objectToSpawn,
                    transform.position + GetRandomSpawnOffset(),
                    Quaternion.identity
                );
                prefab.SetActive(true);
                _spawnedPrefabs.Add(prefab);
            }

            yield return new WaitForSeconds(_spawnerData.GetNewSpawnDelay);
        }
    }

    private bool IsSpawnLimitOn()
    {
        return _spawnerData.GetIsSpawnLimitOn && _spawnedPrefabs.Count > _spawnerData.GetSpawnLimit;
    }

    private void CheckDespawnEnemies()
    {
        if (_spawnerData.GetDespawnOldestOnLimit)
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
                yield return new WaitForSeconds(_spawnerData.GetDespawnDelay);
                enemy.SetActive(false);
                Destroy(enemy);
            }
        }
        _spawnedPrefabs.Clear();
    }

    private IEnumerator DespawnEnemy(GameObject enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(_spawnerData.GetDespawnDelay);
            enemy.SetActive(false);
            Destroy(enemy);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, Vector3.one * 2f);
    }
}
