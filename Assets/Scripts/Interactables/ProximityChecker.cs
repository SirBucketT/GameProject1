using UnityEngine;

public class ProximityChecker : MonoBehaviour
{
    [SerializeField] private bool _proximityIsOn;
    [SerializeField] private GameObject _targetOfRange;
    private bool _targetIsWithinRange = false;
    public bool TargetIsWithinRange => _targetIsWithinRange; 

    private SphereCollider _sphereCollider;
    void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _targetOfRange)
        {
            _targetIsWithinRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _targetOfRange)
        {
            _targetIsWithinRange = false;
        }
    }

    private void OnDrawGizmos()
    {  
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 3f);
        
        if (!_proximityIsOn || _sphereCollider == null)
        {
            return;
        }
        else
        {
        var color = !_targetIsWithinRange ? Color.red : Color.green;
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, _sphereCollider.radius);
        }
    }
}