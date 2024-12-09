using UnityEngine;

[CreateAssetMenu(fileName = "GoldData", menuName = "ScriptableObjects/MoneyManager")]
public class Gold : ScriptableObject
{
    public int gold;
    
    
    public void GetGold(int amount) {
        gold += amount;
    }
}
