using Enemy;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    private EnemyHealthbar _healthbar;
    
    [SerializeField] public float CurrentHealth;
    [SerializeField] public float MaxHealth;
    
    public void TakeDamage(float damage) {
        CurrentHealth -= damage;
        _healthbar.UpdateEnemyHealth();
        Debug.Log($"Enemy damaged: {damage}");
    }
}
