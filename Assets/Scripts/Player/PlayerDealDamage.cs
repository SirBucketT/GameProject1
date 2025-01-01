using System;
using UnityEngine;
public class PlayerDealDamage : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && transform.root.CompareTag("Player"))
        {
            Debug.Log("Collision conditions met.");
            DamageEnemy(other);
        }
    }
    private void DamageEnemy(Collision other)
    {
        other.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damage);
        Debug.Log($"Player dealt {damage} to Enemy!");
    }
}
