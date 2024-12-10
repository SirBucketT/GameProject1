using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SO_EnemyData _enemyData;
    [SerializeField] private  int _numberOfPrefabsToCreate;
    [SerializeField] private Vector3[] _spawnPoints;
    public GameObject EnemyPrefab; 
    private string _prefabName;
    private float spawnDelay = 1f;  
    int instanceNumber = 1;

    private void OnEnable()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = _enemyData.GetEnemyColor;
    }

    private void Start()
    {
        StartCoroutine(SpawnEntitiesWithDelay());
    }
    
    private IEnumerator SpawnEntitiesWithDelay()
    {
        int currentSpawnPointIndex = 0;
        
        for (int i = 0; i < _numberOfPrefabsToCreate; i++)
        {
            Object currentEntity = Instantiate(EnemyPrefab, _spawnPoints[currentSpawnPointIndex], Quaternion.identity);
            currentEntity.name = _prefabName + instanceNumber;
            
            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % _spawnPoints.Length;

            instanceNumber++;
            
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}