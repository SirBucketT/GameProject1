using System;
using UnityEngine;
public class PlayerDealDamage : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField]AudioSource memeMagic;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && transform.root.CompareTag("Player"))
        {
            DamageEnemy(other);
        }
    }
    private void DamageEnemy(Collision other)
    {
        other.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damage);
        Debug.Log($"Player dealt {damage} to Enemy!");
        if (memeMagic != null)
        {
            memeMagic.Play();
        }
    }
}
