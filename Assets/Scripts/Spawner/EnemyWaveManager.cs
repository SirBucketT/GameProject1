using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWaveManager
{
    [SerializeField] List<GameObject> enemiesInWave = new List<GameObject>();
    [SerializeField]  float spawnDelayBetweenEnemies = 1f; 

    
    public List<GameObject> EnemiesInWave => enemiesInWave;
    public float SpawnDelayBetweenEnemies => spawnDelayBetweenEnemies;
}