using UnityEngine;

public class CameraEyeSight : MonoBehaviour
{
    
    [SerializeField] private float fieldOfView = 60f;
    [SerializeField] private float viewDistance = 10f;
    private Collider[] _results;
    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }
    
    void Update()
    {   
            int hitCount = Physics.OverlapSphereNonAlloc(transform.position, viewDistance, _results);
            for (int i = 0; i < hitCount; i++)
            {
                Collider target = _results[i];
                if (Vector3.Angle(transform.forward, (target.transform.position - transform.position).normalized) < fieldOfView / 2) // Dividing the two
                {
                    
                    // For the Npc objects
                    if (target.CompareTag("Npc") && transform.parent.CompareTag("Npc"))
                    {
                        
                    }
                    if (target.CompareTag("Enemy") && transform.parent.CompareTag("Npc"))
                    {
                        
                    }
                    if (target.CompareTag("Player") && transform.parent.CompareTag("Npc"))
                    {
                        Debug.DrawLine(transform.position, target.transform.position, Color.green);
                    }
                    // For the Enemy objects
                    if (target.CompareTag("Enemy") && transform.parent.CompareTag("Enemy"))
                    {
                        
                    }
                    
                    if (target.CompareTag("Npc") && transform.parent.CompareTag("Enemy"))
                    {
                        
                    }
                    if (target.CompareTag("Player") && transform.parent.CompareTag("Enemy"))
                    {
                        Debug.DrawLine(transform.position, target.transform.position, Color.red);
                    }
                    //For the Player object
                    if (target.CompareTag("Npc") && transform.parent.CompareTag("Player"))
                    {
                        
                    }
                    if (target.CompareTag("Enemy") && transform.parent.CompareTag("Player"))
                    {
                        _animator.SetBool("LockedEnemy", true);
                    }
                }
            }
    }
}
