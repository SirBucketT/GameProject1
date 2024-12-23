using UnityEngine;

public class CollectableCoins : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coins collected"); 
        GetCash(1);
        Destroy(this.gameObject);
    }
    void GetCash(int amount) {
        playerData.gold += amount;
    }
}
