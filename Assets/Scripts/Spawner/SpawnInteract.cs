using UnityEngine;
using UnityEngine.Events;

public class SpawnInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private ProximityChecker _proximityChecker;
    [SerializeField] private SpawnerController _spawnerController;
    [SerializeField] private GameObject _interactableObject;
    [SerializeField] private UnityEvent onInteract;

    public void Interact()
    {
        onInteract?.Invoke();
    }

    public void InvokeActivateSpawner()
    {
        ActivateSpawner();
    }
   internal void ActivateSpawner()
    {
        if (HasProxAndController())
        {
            _spawnerController.StartSpawning();
        }
    }

    private bool HasProxAndController()
    {
        return (_proximityChecker != null 
                && _proximityChecker.TargetIsWithinRange 
                && _spawnerController != null);
    }
}