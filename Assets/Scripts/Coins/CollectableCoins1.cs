using UnityEngine;

public class CollectableCoins : MonoBehaviour
{
    [SerializeField] GetCoin getCoin; 
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coins collected"); 
        getCoin.GetCash(1);
        Destroy(this.gameObject);
    }
}
