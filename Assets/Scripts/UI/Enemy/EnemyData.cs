using Enemy;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    EnemyHealthbar _healthbar;
    
    [SerializeField] public float CurrentHealth;
    [SerializeField] public float MaxHealth;
    
    public void EnemyTakeDamage(float damage) {
        CurrentHealth -= damage;
        _healthbar.UpdateEnemyHealth();
        Debug.Log($"Enemy health: {CurrentHealth}");
    }
}
