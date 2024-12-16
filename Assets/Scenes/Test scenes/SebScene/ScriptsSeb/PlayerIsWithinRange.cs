using UnityEngine;

public class PlayerIsWithinRange : MonoBehaviour
{
    [SerializeField] public float interactRadius;
    private bool _playerIsWithinRange { get; set; }
 
    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        _playerIsWithinRange = true;
        Debug.Log("Player is within the range of " + interactRadius);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        _playerIsWithinRange = false;
        Debug.Log("Player is outside the range of " + interactRadius);
    }

    public void OnDrawGizmos()
    { 
        var color = _playerIsWithinRange 
            ? Color.green
            : Color.red;
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, interactRadius );
    }
    public bool IsPlayerWithinRange()
    {
        return _playerIsWithinRange;
    }
}
