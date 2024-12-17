using UnityEngine;

public class PayGold : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    
    public void PayCash(int amount) {
        playerData.gold -= amount;
    }
}
