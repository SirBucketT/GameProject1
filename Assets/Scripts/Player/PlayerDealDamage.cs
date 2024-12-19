using System;
using UnityEngine;
public class PlayerDealDamage : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnCollisionEnter(Collision other)
    {
        var hitObjectRoot = transform.root.gameObject;

        if (other.gameObject.CompareTag("Enemy") && hitObjectRoot.CompareTag("Player"))
        {
            DamageEnemy(other);
        }
    }

    private void DamageEnemy(Collision other)
    {
        other.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damage);
        Debug.Log($"Player dealt {damage} to Enemy!");
    }
}
