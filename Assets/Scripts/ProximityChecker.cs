using UnityEngine;

public class ProximityChecker : MonoBehaviour
{
    [SerializeField] public bool _proximityIsOn;
    [SerializeField] private float _proximityRange;
    [SerializeField] private GameObject _targetOfRange;
    private bool _isWithinRange;
    private bool _targetIsWithinRange;
    
    public void OnDrawGizmos()
    {
        if (!_proximityIsOn) return;
        var color = _targetIsWithinRange 
            ? Color.red
            : Color.green;
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, _proximityRange );

    }
    public void OnTriggerEnter(Collider other)
    {
        if (!_targetOfRange)
            return;
        _targetIsWithinRange = true;
        Debug.Log($"{_targetOfRange} is inside of range");
    }

    public void OnTriggerExit(Collider other)
    {
        if (!_targetOfRange)
            return;
        _targetIsWithinRange = false;
        Debug.Log($"{_targetOfRange} is outside of range");
    }
}