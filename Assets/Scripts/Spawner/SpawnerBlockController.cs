using System.Collections;
using UnityEngine;

public class SpawnerBlockController : MonoBehaviour
{
    [SerializeField] private SO_SpawnerData _spawnerData;
    [SerializeField] private bool _usingProximity;
    [SerializeField] private GameObject _useOtherProximityObject;

    private bool _isSpawning = false;
    private ProximityChecker _proximityChecker;
    private SpawnerManager _spawnerManager;

    private void Awake()
    {
        _spawnerManager = GetComponent<SpawnerManager>();
        if (_spawnerManager == null)
        {
            Debug.LogError("SpawnerManager component is missing from the GameObject!");
            return;
        }
        _spawnerManager.Initialize(_spawnerData, transform);
    }

    private void Start()
    {
        if (_spawnerData == null)
        {
            Debug.LogError("SpawnerData is not assigned in the Inspector!");
            return;
        }

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
        if (_spawnerManager == null || _spawnerData == null)
        {
            yield break;
        }

        yield return StartCoroutine(_spawnerManager.SpawnEntitiesWithDelay(_spawnerData.ForceObjectToSpawn, _spawnerData.ObjectForcedToSpawn, _spawnerData.Waves != null));
    }

    private bool HasObjectForProx()
    {
        return _usingProximity && _useOtherProximityObject != null && _useOtherProximityObject.GetComponent<ProximityChecker>() != null;
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
