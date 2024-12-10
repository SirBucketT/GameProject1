using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] public int CurrentHealth;
    [SerializeField] public int MaxHealth;
    
    public void TakeDamage(int damage) {
        CurrentHealth -= damage;
    }
}
