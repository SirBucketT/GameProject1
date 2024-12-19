using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour, ITakeDamage
{
    [SerializeField] private SO_EnemyData enemyData;

    [SerializeField] int _currentHealth;
    private bool _isAlive;
    
    private bool _isDestroyed = false;
    private bool _isDisabled;
    private static int destroyedCount = 0;
    private static int disabledCount = 0;

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
        if (_currentHealth <= 0 && _isAlive)
        {
            _isAlive = false;
            Debug.Log("Enemy has died.");
            DisableEnemy();
        }
    }

    private void DisableEnemy()
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