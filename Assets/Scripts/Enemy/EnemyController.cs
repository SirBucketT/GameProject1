using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour, IInteractable
{
    [SerializeField] private int _TestPlayerAttackDamage;
    [SerializeField] private float _attackCooldownTime = 1.0f;
    private TakeDamageManager _takeDamageManager;
    private EnemyHealthManager _enemyHealthManager;
    private bool _isAttacked = false;

    private void Start()
    {
        _enemyHealthManager = GetComponent<EnemyHealthManager>();

        if (_enemyHealthManager == null)
        {
            Debug.LogError("EnemyHealthManager component not found on this GameObject!");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isAttacked) 
        {
            Interact();
        }
    }
   
    public void Interact()
    {
        if (!_isAttacked && _enemyHealthManager != null)
        {  
            Debug.Log("Player attacked with" + _TestPlayerAttackDamage + " damage.");
            _takeDamageManager.TakeDamage(_TestPlayerAttackDamage);
            if (this != null && gameObject.activeSelf)
            {
                StartCoroutine(AttackedCooldown());
            }
        }

    }

    private IEnumerator AttackedCooldown()
    {
        _isAttacked = true;
        Debug.Log("Cooldown started");
        
        yield return new WaitForSeconds(_attackCooldownTime); 
        
        _isAttacked = false;
        Debug.Log("Cooldown finished, ready to attack again.");
    }
}