using System;
using UnityEngine;

public class Deal_Damage : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Sword"))
        {
            DamagePlayer(other);
        }
        
        if (other.gameObject.CompareTag("Enemy") && !gameObject.CompareTag("Enemy"))
        {
            DamageEnemy(other);
        }
    }

    private void DamagePlayer(Collision other)
    {
        other.gameObject.GetComponent<PlayerHealth>().PlayerTakeDamage(damage);
        // Debug.Log($"Enemy dealt {damage} to Player!");
    }

    private void DamageEnemy(Collision other)
    {
        other.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damage);
        Debug.Log($"Player dealt {damage} to Enemy!");
    }
}