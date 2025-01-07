using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class EnemyHealthManager : MonoBehaviour, ITakeDamage
{
   
    [SerializeField] private SO_EnemyData soEnemyData;
   
    private bool _isDestroyed = false;
    private ItemDropManager _itemDropManager;
    private EnemyTakeDamageCooldown _enemyTakeDamageCooldown;

    public event Action OnEnemyDeath;
    public UnityEvent OnTakeDamage;

    bool ITakeDamage.isAlive => IsAlive();

    public void Start()
    {
        soEnemyData.ResetEnemyHealth();
        _itemDropManager = GetComponent<ItemDropManager>();
        _enemyTakeDamageCooldown = GetComponent<EnemyTakeDamageCooldown>();
    }

    private bool IsAlive()
    {
        return soEnemyData.GetEnemyHealth > 0 && IsEnabled();
    }

    private bool IsEnabled()
    {
        return gameObject.activeSelf;
    }

    public void TakeDamage(int damageAmount)
    {
        if (!_enemyTakeDamageCooldown.CanTakeDamage())
        {
            return;
        }

        soEnemyData.ReduceEnemyHealth(damageAmount);
        Debug.Log("damage taken");
        if (!IsAlive())
        {
            KillEnemy();
        }

        OnTakeDamage?.Invoke();
    }

    private void KillEnemy()
    {
        gameObject.SetActive(false);
        OnEnemyDeath?.Invoke();
        _itemDropManager.DropItems();
        StartDestroy();
    }

    private void StartDestroy()
    {
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