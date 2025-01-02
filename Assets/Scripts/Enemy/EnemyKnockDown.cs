using UnityEngine;

public class EnemyKnockDown : MonoBehaviour
{
    
    [SerializeField] Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Knockdown()
    {
        _animator.SetTrigger("KnockDown");
    }

    public void TriggerKnockedDown()
    {
        Knockdown();
    }
}
