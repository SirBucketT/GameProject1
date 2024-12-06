using UnityEngine;

public class PLayerIsWithinRange : MonoBehaviour
{
    [SerializeField] public float interactRadius;
    private bool _playerIsWithinRange { get; set; }
    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        _playerIsWithinRange = true;
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        _playerIsWithinRange = false;
    }

    public void OnDrawGizmos()
    {
        var color = _playerIsWithinRange 
            ? Color.green
            : Color.red;
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, interactRadius );
    }
}
