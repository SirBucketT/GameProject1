using UnityEngine;

public class EnemyKnockDown : MonoBehaviour
{
    [SerializeField] Animator _animator;
    
    private void Knockdown()
    {
        _animator.SetTrigger("KnockDown");
    }

    public void TriggerKnockedDown()
    {
        Knockdown();
    }
}
