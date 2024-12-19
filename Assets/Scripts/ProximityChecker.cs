using UnityEngine;

public class ProximityChecker : MonoBehaviour
{
    [SerializeField] public bool _proximityIsOn;
    [SerializeField] private float _proximityRange;
    [SerializeField] private GameObject _targetOfRange;
    private bool _targetIsWithinRange = false;
    public bool TargetIsWithinRange => _targetIsWithinRange; 
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _targetOfRange)
        {
            _targetIsWithinRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _targetOfRange)
        {
            _targetIsWithinRange = false;
        }
        
    }
     public void OnDrawGizmos()
        {
            if (!_proximityIsOn) 
            {
                return;
            }
            else
            {  
            var color = !_targetIsWithinRange 
                ? Color.red
                : Color.green;
            Gizmos.color = color;
            Gizmos.DrawWireSphere(transform.position, _proximityRange);
            }
        }
}
