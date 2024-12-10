using Enemy;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    private EnemyHealthbar _healthbar;
    Attributes_Manager _attributes;
    
    [SerializeField] public float CurrentHealth;
    [SerializeField] public float MaxHealth;
    
    public void EnemyTakeDamage(float damage) {
        CurrentHealth -= damage;
        _healthbar.UpdateEnemyHealth();
        Debug.Log($"Enemy health: {CurrentHealth}");
    }
}
