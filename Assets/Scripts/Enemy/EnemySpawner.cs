using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _numberOfEnemiesToCreate;
    [SerializeField] private Transform _spawnPoint;
    private List<GameObject> _spawnedEnemies = new();
    private  GameObject _spawnedPrefab; 

    WaitForSeconds waitSeconds = new WaitForSeconds(spawnDelay);
    private static float spawnDelay = 1f;  
    int instanceNumber = 1;
   
    
    private void OnEnable()
    {
        StartCoroutine(SpawnEntitiesWithDelay());
    }
    
    private IEnumerator SpawnEntitiesWithDelay()
    {
        int currentSpawnPointIndex = 0;

        for (int i = 0; i < _numberOfEnemiesToCreate; i++)
        {
            Instantiate(_spawnedPrefab, _spawnPoint.position, Quaternion.identity);
            var enemeyReference = Instantiate(_spawnedPrefab, _spawnPoint.position, Quaternion.identity);

            _spawnedEnemies.Add(enemeyReference);
            Debug.Log($"Spawn enemies!");
            yield return new WaitForFixedUpdate();
        }

        StartCoroutine(DespawnEnemies());
    }

    IEnumerator DespawnEnemies()
    {
        yield return waitSeconds;
        foreach (var _spawnedObjects in _spawnedEnemies)
        {
            Destroy(_spawnedObjects);
            yield return new WaitForFixedUpdate();
        }
    }
}