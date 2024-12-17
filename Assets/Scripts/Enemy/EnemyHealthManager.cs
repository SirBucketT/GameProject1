using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField] private SO_EnemyData enemyData;
    private TakeDamageManager _takeDamageManager;
    private int _currentHealth;
    private bool _isDestroyed = false;
    private bool _isDisabled;
    private bool isAlive => _takeDamageManager._isAlive;
    
    private static int destroyedCount = 0;
    private static int disabledCount = 0;
    

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
        Debug.Log("Enemy Initialized with health: " + _currentHealth); 
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} has died.");
        _isDestroyed = true;
        DisableObject();
    }
    private void DisableObject()
    {
        if (_currentHealth <= 0 && !_takeDamageManager._isAlive && !_isDisabled) 
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