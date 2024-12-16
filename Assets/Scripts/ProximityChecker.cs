using UnityEngine;

public class ProximityChecker : MonoBehaviour
{
    [SerializeField] public bool ProximityIsOn;
    [SerializeField] private float ProximityRange;
    [SerializeField] private GameObject _targetOfRange;
    // private bool _isWithinRange;
    // private bool _targetIsWithinRange;

    // public void OnDrawGizmos()
    // {
    //     if (!ProximityIsOn) return;
    //     {
    //             
    //         var color = _targetOfRange
    //             ? Color.green
    //             : Color.red;
    //         Gizmos.color = color;
    //         Gizmos.DrawWireSphere(transform.position, ProximityRange);
    //     }
    // }

    private void ActivateProximity()
    {
        if (ProximityIsOn == true)
        {
            OnDrawGizmos();
        }
    }
    public void OnDrawGizmos()
    {
        var color = _targetOfRange
            ? Color.green
            : Color.red;
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, ProximityRange);
    }
}