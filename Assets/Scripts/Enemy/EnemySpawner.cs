using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _numberOfEnemiesToCreate;
    [SerializeField] private Transform _spawnPoint;  
    [SerializeField] private GameObject _spawnedPrefab;  
    [SerializeField] private bool _isDestroyedOnTimer;  
    [SerializeField] private float spawnDelay = 1f;  
    [SerializeField] private float destroyDelay = 1f;  

    private List<GameObject> _spawnedEnemies = new();  

    private void Start()
    {
        StartCoroutine(SpawnEntitiesWithDelay());
    }
    private IEnumerator SpawnEntitiesWithDelay()
    {
        for (int i = 0; i < _numberOfEnemiesToCreate; i++)
        {
            GameObject enemy = Instantiate(_spawnedPrefab, _spawnPoint.position, Quaternion.identity);
            _spawnedEnemies.Add(enemy); 
            Debug.Log($"Spawned enemy {i + 1} of {_numberOfEnemiesToCreate}");
            yield return new WaitForSeconds(spawnDelay);
        }
        
        if (_isDestroyedOnTimer)
        {
            StartCoroutine(DespawnEnemies());
        }
    }

    private IEnumerator DespawnEnemies()
    {
        yield return new WaitForSeconds(destroyDelay);
        foreach (var enemy in _spawnedEnemies)
        {
            if (enemy != null)
            {
                Destroy(enemy);
                Debug.Log("Destroyed enemy.");
                yield return new WaitForFixedUpdate();  
            }
        }
        _spawnedEnemies.Clear();
        Debug.Log("All enemies destroyed.");
    }
}