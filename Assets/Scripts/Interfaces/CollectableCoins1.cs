using UnityEngine;

public class CollectableCoins : MonoBehaviour
{
    public int coins;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider col)
    {
       if (col.gameObject.tag == "Coins")
        {
            Debug.Log("Coins collected");
            coins = coins + +1;
            col.gameObject.SetActive(false);    
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
