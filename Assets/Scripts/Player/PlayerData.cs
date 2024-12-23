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
    
}
