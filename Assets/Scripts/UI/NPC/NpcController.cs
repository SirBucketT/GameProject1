using UnityEngine;

public class NpcController : MonoBehaviour
{
    public bool PlayerIsWithinRange { get; private set; }
    [SerializeField] GameObject npcDialgue;

    void Start()
    {
        npcDialgue.SetActive(false);
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        PlayerIsWithinRange = true;
        npcDialgue.SetActive(true);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        PlayerIsWithinRange = false;
        npcDialgue.SetActive(false);
    }

    public void OnDrawGizmos()
    {
        var color = PlayerIsWithinRange 
            ? Color.green
            : Color.red;
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, 4);
    }
}