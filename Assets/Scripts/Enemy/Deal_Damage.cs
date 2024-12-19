using System;
using UnityEngine;

public class Deal_Damage : MonoBehaviour
{
    [SerializeField] private int damage;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().PlayerTakeDamage(damage);
            Debug.Log($"Enemy dealt {damage} to Player!");
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damage);
            Debug.Log($"Player dealt {damage} to Enemy!");
        }
    }
}
