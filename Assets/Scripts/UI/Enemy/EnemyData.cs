using Enemy;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    private EnemyHealthbar healthbar;
    
    [SerializeField] public float CurrentHealth;
    [SerializeField] public float MaxHealth;
    
    public void TakeDamage(float damage) {
        CurrentHealth -= damage;
        healthbar.UpdateEnemyHealth();
    }
}
