using UnityEngine;

[CreateAssetMenu(fileName = "SO_SpawnerData", menuName = "ScriptableObjects/SO_SpawnerData", order = 1)]
public class SO_SpawnerData : ScriptableObject
{
    public GameObject spawnedPrefab;
    public int numberOfPrefabsToCreate;
    public float firstSpawnDelay = 1f;
    public float newSpawnDelay = 1f;
    public bool isSpawnLimitOn;
    public bool despawnOldestOnLimit;
    public float spawnLimit;
    public float despawnDelay = 1f;
}