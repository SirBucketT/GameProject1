using System.Collections;
using UnityEngine;

public class SpawnInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private ProximityChecker _proximityChecker;
    [SerializeField] SpawnerController _spawnerController;

    private void Awake()
    {
        if (_proximityChecker == null)
        {
            _proximityChecker = GetComponentInChildren<ProximityChecker>();
        }
    }

    public void Interact()
    {
        ActivateSpawner();
    }

    internal void ActivateSpawner()
    {
        if (_proximityChecker != null && _proximityChecker.TargetIsWithinRange)
        {
            _spawnerController.StartSpawning();
        }
    }
}