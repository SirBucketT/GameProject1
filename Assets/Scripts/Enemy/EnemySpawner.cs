using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _numberOfEnemiesToCreate;
    [SerializeField] GameObject _spawnedPrefab;
    [SerializeField] bool _isDestroyedOnDelay;
    [SerializeField] float spawnDelay = 1f;
    [SerializeField] float destroyDelay = 1f;
    private bool _hasSpawnedAllEnemies = false;

    private List<GameObject> _spawnedEnemies = new();

    private void Start()
    {
        StartCoroutine(SpawnEntitiesWithDelay());
    }

    private GameObject EnemyInstantiate()
    {
        GameObject enemy = Instantiate(_spawnedPrefab, transform.position, Quaternion.identity);
        EnemySetActive(enemy);
        return enemy;  
    }

    private void EnemySetActive(GameObject enemy)
    {
        if (enemy != null)
        {
            enemy.SetActive(true);  
        }
    }

    private void Update()
    {
        if (_hasSpawnedAllEnemies && _isDestroyedOnDelay && _spawnedEnemies.Count > 0)
        {
            StartCoroutine(DestroyEnemies());
            _hasSpawnedAllEnemies = false; 
        }
    }

    private IEnumerator SpawnEntitiesWithDelay()
    {
        for (int i = 0; i < _numberOfEnemiesToCreate; i++)
        {
            GameObject enemy = EnemyInstantiate();  
            _spawnedEnemies.Add(enemy);  
            Debug.Log($"Spawned enemy {i + 1} of {_numberOfEnemiesToCreate}");

            yield return new WaitForSeconds(spawnDelay);  
        }
        
        _hasSpawnedAllEnemies = true;
    }
    
    private IEnumerator DestroyEnemies()
    {
        yield return new WaitForSeconds(destroyDelay);
        foreach (var enemy in _spawnedEnemies)
        {
            if (enemy != null)
            {
                Destroy(enemy); 
                yield return new WaitForFixedUpdate();  
            }
        }
        _spawnedEnemies.Clear();  
    }
   
    private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawCube(transform.position, Vector3.one);
        }
}
