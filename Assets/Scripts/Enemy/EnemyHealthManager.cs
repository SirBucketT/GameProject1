using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealthManager : MonoBehaviour, ITakeDamage
{
    [SerializeField] private SO_EnemyData enemyData;
    [SerializeField] private int _currentHealth;
    [SerializeField] private ItemDrop itemDrop;
    public event Action OnEnemyDeath;
    private bool _isDestroyed = false;

    bool ITakeDamage.isAlive => IsAlive();

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
    }
    
    private bool IsAlive()
    {
        return _currentHealth > 0 && IsEnabled();
    }

    private bool IsEnabled()
    {
        return gameObject.activeSelf;
    }

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        if (!IsAlive())
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        gameObject.SetActive(false);
        OnEnemyDeath?.Invoke();

        if (this != null && IsEnabled())
        { 
            StartCoroutine(DestroyLater());
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