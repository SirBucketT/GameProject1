using UnityEngine;

public class ProximityChecker : MonoBehaviour
{
    [SerializeField] private GameObject _targetOfRange;
    private bool _targetIsWithinRange = false;
    private bool _proximityIsOn = true;
    public bool TargetIsWithinRange => _targetIsWithinRange; 

    private SphereCollider _sphereCollider;
    
    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.isTrigger = true;
    }
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

    private bool HasCollider(Collider collider)
    {
        return _proximityIsOn || _sphereCollider == null;
    }
    private void OnDrawGizmos()
    {  
        if (HasCollider(_sphereCollider))
        {
            float radius = _sphereCollider != null ? _sphereCollider.radius : 3f;
            var color = !_targetIsWithinRange ? Color.red : Color.green;
            Gizmos.color = color;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}