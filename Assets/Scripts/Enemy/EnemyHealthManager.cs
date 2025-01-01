using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyHealthManager : MonoBehaviour, ITakeDamage
{
    [SerializeField] private SO_EnemyData enemyData;
    [SerializeField] private int _currentHealth;
    
    private ItemDrop _itemDrop; 
    private bool _isDestroyed = false;

    public event Action OnEnemyDeath;

    bool ITakeDamage.isAlive => IsAlive();

    public void Start()
    {
        Initialize();
        _itemDrop = GetComponent<ItemDrop>();  
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
        DropItems();
        StartDestroy();
    }

    private void StartDestroy()
    {
        if (this != null && IsEnabled())
        { 
            StartCoroutine(DestroyLater());
        }
    }
    private void DropItems()
    {
        if (_itemDrop != null)
        {
            _itemDrop.DropItems(); 
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
