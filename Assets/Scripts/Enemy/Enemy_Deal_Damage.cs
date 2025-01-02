using System;
using UnityEngine;

public class Enemy_Deal_Damage : MonoBehaviour
{
    [SerializeField] SO_EnemyData EnemyDamage;
    [SerializeField] private float damageCooldown = 1.0f;
    private float _lastDamageTime;

    private void OnCollisionEnter(Collision other)
    {
        var hitObjectRoot = transform.root.gameObject;
        
        if (other.gameObject.CompareTag("Player") && hitObjectRoot.CompareTag("Enemy"))
        {
            DamagePlayer(other);
        }
    }

    private void DamagePlayer(Collision other)
    {
        if (Time.time >= _lastDamageTime + damageCooldown)
        {
            other.gameObject.GetComponent<PlayerHealth>().PlayerTakeDamage(EnemyDamage.GetEnemyDamage);
        _lastDamageTime = Time.time; 
        }
    }
}