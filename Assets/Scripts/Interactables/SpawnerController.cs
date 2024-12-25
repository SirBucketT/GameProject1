using System.Collections;
using System.Collections.Generic;
using UnityEngine;
internal class SpawnerController : MonoBehaviour
{
    [SerializeField] private SO_SpawnerData _spawnerData;
    [SerializeField] private GameObject _objectForcedToSpawn;
    [SerializeField] private bool _ForceObjectToSpawn;
    [SerializeField] private bool _usingProximity;
    [SerializeField] private bool _usingSOWaves;
    private bool _hasSpawned = false;
    private ProximityChecker _proximityChecker;
    private List<GameObject> _spawnedPrefabs = new List<GameObject>();
    private Vector3 _spawnPositionOffset;
    private int _remainingEnemies; 

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
            return;
        }
        CheckForProximity();
    }
    
    private void Update()
    {
        if (IsWithinProximity())
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
            return;
        }

        if (!_usingProximity)
        {
            StartCoroutine(SpawnEntitiesWithDelay());
        }
    }
    private IEnumerator SpawnEntitiesWithDelay()
    {
        yield return new WaitForSeconds(_spawnerData.GetFirstSpawnDelay);

        if (_usingSOWaves && !_ForceObjectToSpawn)
        {
            yield return SpawnWaves();
        }
        else if (_ForceObjectToSpawn)
        {
            yield return SpawnObjects();
        }

        if (IsSpawnLimitOn())
        {
            CheckDespawnEnemies();
        }
    }
    private IEnumerator SpawnWaves()
    {
        if (_spawnerData == null || _spawnerData.Waves == null)
        {
            yield break;
        }

        foreach (var wave in _spawnerData.Waves)
        {
            yield return StartCoroutine(CheckWave(wave));
        
            yield return new WaitForSeconds(_spawnerData.GetNewSpawnDelay);
        }
    }

    private IEnumerator CheckWave(EnemyWaveManager wave)
    {
        _remainingEnemies = wave.EnemiesInWave.Count;

        foreach (var enemyPrefab in wave.EnemiesInWave)
        {
            InstantiateEnemyPrefab(enemyPrefab);
            yield return new WaitForSeconds(wave.SpawnDelayBetweenEnemies);
        }
    
        yield return new WaitUntil(() => IsWaveDefeated());
    }

    private void InstantiateEnemyPrefab(GameObject enemyPrefab)
    {
        if (enemyPrefab != null)
        {
            GameObject instantiatedPrefab = Instantiate(
                enemyPrefab,
                transform.position + GetRandomSpawnOffset(),
                Quaternion.identity
            );

            instantiatedPrefab.SetActive(true);
            _spawnedPrefabs.Add(instantiatedPrefab);
            
            EnemySubscribeToDeath(instantiatedPrefab);
        }
    }

    private void EnemySubscribeToDeath(GameObject prefab)
    {
        EnemyHealthManager enemyHealthManager = prefab.GetComponent<EnemyHealthManager>();
        if (enemyHealthManager != null)
        {
            enemyHealthManager.OnEnemyDeath += CountEnemyDeath;
        }
    }

    private bool IsWithinProximity()
    {
        return _usingProximity && _proximityChecker != null && _proximityChecker.TargetIsWithinRange && !_hasSpawned;
    }

    private bool IsWaveDefeated()
    {
        return _remainingEnemies <= 0;
    }
    
    private Vector3 GetRandomSpawnOffset()
    {
        return new Vector3(
            Random.Range(-1f, 1f),
            0f,
            Random.Range(-1f, 1f)
        );
    }

    public void CountEnemyDeath()
    {
        _remainingEnemies--;
    }

    private IEnumerator SpawnObjects()
    {
        for (int i = 0; i < _spawnerData.GetNumberOfPrefabsToCreate; i++)
        {
            if (_objectForcedToSpawn != null)
            {
                GameObject prefab = Instantiate(
                    _objectForcedToSpawn,
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