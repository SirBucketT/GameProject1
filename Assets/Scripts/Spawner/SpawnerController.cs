using System.Collections;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private SO_SpawnerData _spawnerData;
    [SerializeField] private bool _usingProximity;
    [SerializeField] private GameObject _useOtherProximityObject;

    private bool _isSpawning = false;
    private ProximityChecker _proximityChecker;
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = new Spawner(_spawnerData, transform);
    }

    private void Start()
    {
        if (!_usingProximity)
        {
            StartSpawning();
        }
        else if (HasObjectForProx())
        {
            _proximityChecker = _useOtherProximityObject.GetComponent<ProximityChecker>();
        }
        else
        {
            _proximityChecker = GetComponentInChildren<ProximityChecker>();
        }
    }

    private void Update()
    {
        if (TargetIsWithinRange() && !_isSpawning)
        {
            StartSpawning();
        }
    }

    internal void StartSpawning()
    {
        if (_isSpawning)
        {
            return;
        }

        _isSpawning = true;
        StartCoroutine(SpawnWithLoop());
    }

    private IEnumerator SpawnWithLoop()
    {
        do
        {
            yield return SpawnWithDelay(); 
        } while (_spawnerData.GetIsLooping); 

        _isSpawning = false;
    }

    private IEnumerator SpawnWithDelay()
    {
        yield return StartCoroutine(_spawner.SpawnEntitiesWithDelay(_spawnerData.ForceObjectToSpawn, _spawnerData.ObjectForcedToSpawn, _spawnerData.Waves != null));
    }

    private bool HasObjectForProx()
    {
        return _proximityChecker && _useOtherProximityObject != null && _usingProximity;
    }

    private bool TargetIsWithinRange()
    {
        return _proximityChecker != null && _proximityChecker.TargetIsWithinRange && !_isSpawning;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, Vector3.one * 2f);

        if (_useOtherProximityObject != null)
        {
            Transform attachedProx = _useOtherProximityObject.transform;

            if (attachedProx != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, attachedProx.position);
            }
        }
    }
}
