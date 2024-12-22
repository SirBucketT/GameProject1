using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_SpawnerData", menuName = "ScriptableObjects/SO_SpawnerData", order = 1)]
public class SO_SpawnerData : ScriptableObject
{
   
   [SerializeField] int numberOfPrefabsToCreate;
   [SerializeField] float firstSpawnDelay = 1f;
   [SerializeField] float newSpawnDelay = 1f;
   [SerializeField] bool isSpawnLimitOn;
   [SerializeField] bool despawnOldestOnLimit;
   [SerializeField] float spawnLimit;
   [SerializeField] float despawnDelay = 1f;
   [SerializeField] private List<EnemyWaveManager> waves = new List<EnemyWaveManager>();
   
   public int GetNumberOfPrefabsToCreate => numberOfPrefabsToCreate;
   public float GetFirstSpawnDelay => firstSpawnDelay;
   public float GetNewSpawnDelay => newSpawnDelay;
   public bool GetIsSpawnLimitOn => isSpawnLimitOn;
   public bool GetDespawnOldestOnLimit => despawnOldestOnLimit;
   public float GetSpawnLimit => spawnLimit;
   public float GetDespawnDelay => despawnDelay;
   public List<EnemyWaveManager> Waves => waves;
}