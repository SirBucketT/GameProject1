using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnerWaveManager
{
    [SerializeField] private List<GameObject> _objectsInWave = new List<GameObject>();
    [SerializeField] private float _spawnDelayBetweenObjects = 1f;

    public List<GameObject> ObjectsInWave => _objectsInWave;
    public float SpawnDelayBetweenObjects => _spawnDelayBetweenObjects;
}