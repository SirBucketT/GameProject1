using UnityEngine;

public class ProximityChecker : MonoBehaviour
{
    private bool _isWithinRange;
    private bool _targetIsWithinRange;
    [SerializeField] public bool ProximityIsOn;
    [SerializeField] private float ProximityRange;
    [SerializeField] private GameObject _targetOfRange;

    public void OnDrawGizmos()
    {
        if (ProximityIsOn)
        {
            var color = _isWithinRange
                ? Color.green
                : Color.red;
            Gizmos.color = color;
            Gizmos.DrawWireSphere(transform.position, ProximityRange);
        }
    }
}