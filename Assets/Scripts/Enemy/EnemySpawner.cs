using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _numberOfPrefabsToCreate;
    [SerializeField] private Transform _spawnPoint;
    List<GameObject> 
    public GameObject EnemyPrefab; 

    WaitForSeconds waitSeconds = new WaitForSeconds(spawnDelay);
    WaitForFixedUpdate waitFixedUpdate = new WaitForFixedUpdate();
    private static float spawnDelay = 1f;  
    int instanceNumber = 1;
   
    
    private void Start()
    {
        StartCoroutine(SpawnEntitiesWithDelay());
    }
    
    private IEnumerator SpawnEntitiesWithDelay()
    {
        int currentSpawnPointIndex = 0;
        
        for (int i = 0; i < _numberOfPrefabsToCreate; i++)
        { 
            Instantiate(EnemyPrefab, _spawnPoint.position, Quaternion.identity);
            Debug.Log($"Spawn enemies!");
            yield return waitFixedUpdate;
        }
    }
}