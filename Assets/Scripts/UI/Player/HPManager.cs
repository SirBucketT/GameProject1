using Enemy;
using UnityEngine;
using UI.Player;

[CreateAssetMenu(fileName = "HP Manager", menuName = "ScriptableObjects/HP Manager")]
public class HPManager : ScriptableObject
{
    HealthbarManager HPbar;
    public float maxHP;
    public float currentHP;
    
    public void PlayerTakeDamage(float damage)
    {
        currentHP -= damage;
        Debug.Log("spaceBar pressed, you lose 10 health");
        Debug.Log($"Player health: {currentHP}");
        HPbar.UpdateHealthBarMaxValue();
    }
     
}
