using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class SpawnInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private ProximityChecker _proximityChecker;
    [SerializeField] private SpawnerBlockController _spawnerBlockController;
    [SerializeField] private GameObject _interactableObject;
    [SerializeField] private UnityEvent _onInteract;

    public void Interact()
    {
        _onInteract?.Invoke();
    }

    public void InvokeActivateSpawner()
    {
        ActivateSpawner();
    }
   internal void ActivateSpawner()
    {
        if (HasProxAndController())
        {
            _spawnerBlockController.StartSpawning();
        }
    }

    private bool HasProxAndController()
    {
        return (_proximityChecker != null 
                && _proximityChecker.TargetIsWithinRange 
                && _spawnerBlockController != null);
    }
}