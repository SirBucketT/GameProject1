using UnityEngine;

public class GetCoin : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    
    public void GetCash(int amount) {
        playerData.gold += amount;
    }
}
