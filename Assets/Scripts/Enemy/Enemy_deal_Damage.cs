using System;
using UnityEngine;

public class Enemy_deal_Damage : MonoBehaviour
{
    [SerializedField] private int damage;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().PlayerTakeDamage(damage);
            Debug.Log($"Enemy dealt {damage} to Player!");
        }
    }
}
