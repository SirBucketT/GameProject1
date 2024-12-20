using System;
using UnityEngine;

public class LongSword : MonoBehaviour
{
    EnemyHealthManager _enemyHealth;

    private PlayerHealth _playerHealth;

    private PlayerData _playerData;
    private SO_EnemyData _enemyData;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.body.CompareTag("Enemy"))
        {
            _enemyHealth.TakeDamage(_playerData.SwordAttack);
        }
        if (collision.body.CompareTag("Player"))
        {
            _playerHealth.PlayerTakeDamage(_enemyData.GetEnemyDamage);
        }
    }
}
