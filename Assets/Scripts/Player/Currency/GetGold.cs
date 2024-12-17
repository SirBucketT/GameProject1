using UnityEngine;

public class GetGold : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    
    public void GetCash(int amount) {
        playerData.gold += amount;
    }
}
