using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_SpawnerData", menuName = "ScriptableObjects/SO_SpawnerData", order = 1)]
public class SO_SpawnerData : ScriptableObject
{ 
    [Header("Spawn Settings")]
    [SerializeField] private float _firstSpawnDelay = 1f;
    [SerializeField] private float _newSpawnDelay = 1f;
    [SerializeField] private bool _despawnOldestOnLimit;
    [SerializeField] private float _spawnLimit; 
    [SerializeField] private float _despawnDelay = 1f;
    [SerializeField] private bool _isLooping;

    [Header("Forced Spawn Settings")]
    [SerializeField] private bool _forceObjectToSpawn;
    [SerializeField] private GameObject _objectForcedToSpawn;

    [Header("Prefab List Settings")]
    [SerializeField] private List<SpawnerWaveManager> _waves = new List<SpawnerWaveManager>();

    public float GetFirstSpawnDelay => _firstSpawnDelay;
    public float GetNewSpawnDelay => _newSpawnDelay;
    public bool GetDespawnOldestOnLimit => _despawnOldestOnLimit;
    public float GetSpawnLimit => _spawnLimit;
    public float GetDespawnDelay => _despawnDelay;
    public List<SpawnerWaveManager> Waves => _waves;
    public bool GetIsLooping => _isLooping;

    public bool HasSpawnLimit => _spawnLimit > 0;

    public bool ForceObjectToSpawn => _forceObjectToSpawn;
    public GameObject ObjectForcedToSpawn => _objectForcedToSpawn;
}