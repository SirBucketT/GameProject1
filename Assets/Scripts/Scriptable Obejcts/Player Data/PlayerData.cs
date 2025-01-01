using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("Player Money")]
    public int gold;
    
    [Header("Player Mana")]
    public float currentMp;
    public float maxMp;
    
    [Header("Player health")]
    public float maxHealth;
    public float currentHealth;

    [Header("Player Level")]
    public int playerLevel;
    public int playerMaxLevel;

    [Header("Player experience")]
    public float minExp;
    public float maxExp;
    public float currentExp;

    [Header("Player Damage")] 
    [SerializeField] public GameObject Sword;
    [SerializeField] public int SwordAttack = 10;

    public void EnableCollision()
    {
        if (Sword != null)
        {
            Collider swordCollider = Sword.GetComponent<Collider>();
            if (swordCollider != null)
            {
                swordCollider.enabled = true;
            }
            else {Debug.Log("Sword collider missing!");}
        } else {Debug.Log("Sword is null!");}
    }
    public void DisableCollision()
    {
        if (Sword != null)
        {
            Collider swordCollider = Sword.GetComponent<Collider>();
            if (swordCollider != null)
            {
                swordCollider.enabled = false;
            }
            else{Debug.Log("Sword collider is null!");}
        } else {Debug.Log("Sword is null!");}
    }
    
}
