using UnityEngine;
using UI.Player;

[CreateAssetMenu(fileName = "HP Manager", menuName = "ScriptableObjects/HP Manager")]
public class HPManager : ScriptableObject
{
    public float maxHP;
    public float currentHP;
    
    public void TakeDamage(float damage) {
        currentHP -= damage;
        Debug.Log("spaceBar pressed, you lose 10 health");
        Debug.Log($"Player health: {currentHP}");

        if (currentHP <= 0)
        {
            currentHP = 0;
        }
    }
}
