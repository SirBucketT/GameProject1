using UnityEngine;

public class CollectableCoins : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    public void OnTriggerEnter(Collider col)
    {
       if (col.gameObject.tag == "Coins")
       {
            Debug.Log("Coins collected");
            GetCash(1);
            Destroy(this.gameObject);
            //col.gameObject.SetActive(false);    
       }
    }
    void GetCash(int amount) {
        playerData.gold += amount;
    }
}
