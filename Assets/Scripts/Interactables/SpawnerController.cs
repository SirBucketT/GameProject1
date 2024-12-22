using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class SpawnerController : MonoBehaviour
{
    [SerializeField] private SO_SpawnerData _spawnerData;
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private bool _usingProximity;
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
            return;
        }

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

    private void Update()
    {
        if (_usingProximity && _proximityChecker != null && _proximityChecker.TargetIsWithinRange && !_hasSpawned)
        {
            _hasSpawned = true;
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
        if (objectToSpawn == null)
        {
            return null;
        }

        GameObject enemy = Instantiate(objectToSpawn, transform.position + GetRandomSpawnOffset(), Quaternion.identity);
        enemy.SetActive(true);
        return enemy;
    }


    private IEnumerator SpawnEntitiesWithDelay()
    {
        yield return new WaitForSeconds(_spawnerData.GetFirstSpawnDelay);

        for (int i = 0; i < _spawnerData.GetNumberOfPrefabsToCreate; i++)
        {
            GameObject enemy = EnemyInstantiate();
            _spawnedPrefabs.Add(enemy);

            if (_spawnerData.GetIsSpawnLimitOn && _spawnedPrefabs.Count > _spawnerData.GetSpawnLimit)
            {
                CheckDespawnEnemies();
            }

            yield return new WaitForSeconds(_spawnerData.GetNewSpawnDelay);
        }
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
