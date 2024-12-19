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
            
            return;
        }
        _currentHealth = enemyData.GetEnemyHealth;
        _isAlive = true;
        
    }

    public void TakeDamage(int damageAmount)
    {
        if (!_isAlive) return;

        _currentHealth -= damageAmount;
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
            
            _isDestroyed = true;
        }
    }

}