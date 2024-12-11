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
    [SerializeField] private  GameObject _spawnedPrefab;
    [SerializeField] private bool _IsDestroyedOnTimer;
    
    [SerializeField] float spawnDelay = 1f;  
    [SerializeField] float destroyDelay = 1f;  
    int instanceNumber = 1;
   
    
    private void Start()
    {
        StartCoroutine(SpawnEntitiesWithDelay());
    }
    
    private IEnumerator SpawnEntitiesWithDelay()
    {
        int currentSpawnPointIndex = 0;

        for (int i = 0; i < _numberOfEnemiesToCreate; i++)
        {
            var enemeyReference = Instantiate(_spawnedPrefab, _spawnPoint.position, Quaternion.identity);

            _spawnedEnemies.Add(enemeyReference);
            Debug.Log($"Spawn enemies!");
            yield return new WaitForSeconds(spawnDelay);
        }

        StartCoroutine(DespawnEnemies());
    }

    IEnumerator DespawnEnemies()
    { 
        if (_IsDestroyedOnTimer)
            yield return new WaitForSeconds(destroyDelay);
        foreach (var _spawnedObjects in _spawnedEnemies)
        {
            Destroy(_spawnedObjects);
            yield return new WaitForFixedUpdate();
        }
    }
}