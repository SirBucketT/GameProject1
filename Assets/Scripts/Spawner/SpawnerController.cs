using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private SO_SpawnerData _spawnerData;
    [SerializeField] private GameObject _objectForcedToSpawn;
    [SerializeField] private bool _forceObjectToSpawn;
    [SerializeField] private bool _usingProximity;
    [SerializeField] private bool _usingSOWaves;
    [SerializeField] private GameObject _proximityObject;
    private bool _hasSpawned = false;
    private ProximityChecker _proximityChecker;
    private Spawner _spawner;

   
    private void Awake()
    {
        _spawner = new Spawner(_spawnerData, transform);
    }
    
    private void Start()
    {
        if (!UsesProximity())
        {
            StartSpawning();
        }

        if (HasObjectForProx())
        {
            _proximityChecker = _proximityObject.GetComponent<ProximityChecker>();
        }
        else
        {
            _proximityChecker = GetComponentInChildren<ProximityChecker>();
        }
    }
    
    private void Update()
    {
        if (TargetIsWithinRange())
        {
            _hasSpawned = true;
            StartSpawning();
        }
    }
    internal void StartSpawning()
    {
        StartCoroutine(_spawner.SpawnEntitiesWithDelay(_forceObjectToSpawn, _objectForcedToSpawn, _usingSOWaves));
    }
    private bool HasObjectForProx()
    {
        return _proximityChecker && _proximityObject  && _usingProximity;
    }
    private bool UsesProximity()
    {
        return _spawnerData != null && _usingProximity;
    }
    private bool TargetIsWithinRange()
    {
        return _proximityChecker != null && _proximityChecker.TargetIsWithinRange && !_hasSpawned;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, Vector3.one * 2f);
        
        Transform attachedProx = _proximityObject.transform;
        if (attachedProx != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, attachedProx.position);
        }
    }
}