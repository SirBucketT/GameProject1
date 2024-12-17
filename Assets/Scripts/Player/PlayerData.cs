using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public int gold;
    
    public float currentMp;
    public float maxMp;
    
    public float maxHealth;
    public float currentHealth;

    public int playerLevel;
    public int playerMaxLevel;

    public float minExp;
    public float maxExp;
    public float currentExp;
}
