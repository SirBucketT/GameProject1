using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    private int PlayerHealth = 100;
    void player_take_damage()
    {
        PlayerHealth - Enemy_deal_Damage.damage;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
