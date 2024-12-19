using System;
using UnityEngine;

public class Enemy_Deal_Damage : MonoBehaviour
{
    [SerializeField] SO_EnemyData EnemyDamage;

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
        other.gameObject.GetComponent<PlayerHealth>().PlayerTakeDamage(EnemyDamage.GetEnemyDamage);
        Debug.Log($"Enemy dealt {EnemyDamage.GetEnemyDamage} to Player!");
    }
}