using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemiesToSpawn;
    [SerializeField] private Vector3[] _spawnPoints;
    private float spawnDelay = 1f;  

    [SerializeField] private SO_EnemyData _enemyData;
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
        
        foreach (var enemy in _enemiesToSpawn)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % _spawnPoints.Length;
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}