using UnityEngine;

public class GetGold : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    
    public void GetGold(int amount) {
        playerData.gold += amount;
    }
}
