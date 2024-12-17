using UnityEngine;

public class TakeDamageManager : MonoBehaviour
{ 
    internal bool _isAlive;
    internal int _maxHealth; 
    internal int _currentHealth;

    public void TakeDamage(int damageAmount)
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
    }
}
