using System;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour, ITakeDamage
{
    [SerializeField] private SO_EnemyData enemyData;

    private int _currentHealth;
    private bool _isAlive;

    bool ITakeDamage.isAlive => _isAlive;

    public void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (enemyData == null)
        {
            Debug.LogError("EnemyData is not assigned!");
            return;
        }
        _currentHealth = enemyData.GetEnemyHealth;
        _isAlive = true;
        Debug.Log("Enemy Initialized with health: " + _currentHealth); 
    }

    public void TakeDamage(int damageAmount)
    {
        if (!_isAlive) return;

        _currentHealth -= damageAmount;
        Debug.Log("Enemy took damage. Current health: " + _currentHealth); 

        if (_currentHealth <= 0)
        {
            _isAlive = false;
            Debug.Log("Enemy has died.");  
        }
    }
}