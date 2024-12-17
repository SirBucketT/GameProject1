using System.Collections;
using UnityEngine;

public class TakeDamageManager : MonoBehaviour
{
    internal bool _isAlive;
    internal int _maxHealth; 
    internal int _currentHealth;
  
    private bool _isDestroyed = false;
    private bool _isDisabled;
    
    private static int destroyedCount = 0;
    private static int disabledCount = 0;
    public virtual void TakeDamage(int damageAmount)
    {
        if (!_isAlive) return;

        _currentHealth -= damageAmount;
        Debug.Log($"{gameObject} took damage. Current health: " + _currentHealth);
        if (_currentHealth <= 0 && _isAlive)
        {
            Death();
        }
    }

    private void Death()
    {
        _isAlive = false;
        Debug.Log($"{gameObject} has died.");
        _isDestroyed = true;
        DisableObject();
    }
    private void DisableObject()
    {
        if (_currentHealth <= 0 && !_isAlive && !_isDisabled) 
        {
            _isDisabled = true;
            
            gameObject.SetActive(false);
            disabledCount++;
            Debug.Log($"Enemy disabled (SetActive false). Total disabled count: {disabledCount}. GameObject: {gameObject.name}");
            
            if (this != null && gameObject.activeSelf)
            {
                StartCoroutine(DestroyLater());
            }
        }
    }
    
    private IEnumerator DestroyLater()
    {
        yield return new WaitForSeconds(5f);
    
        if (gameObject != null && !_isDestroyed)
        {
            Destroy(this.gameObject);
            destroyedCount++;  
            Debug.Log($"Enemy destroyed (GameObject destroyed). " +
                      $"Total destroyed count: {destroyedCount}. GameObject: {gameObject.name}");
            _isDestroyed = true;
        }
    }
}
