using UnityEngine;

public class GainExperiance : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] EXPManager experianceManager;
    
    public void GainExperiancePoints(float expGain)
    {
        playerData.currentExp += expGain;
        Debug.Log($"you gained {expGain} EXP");
        
        if (playerData.playerLevel >= playerData.playerMaxLevel)
        {
            playerData.playerLevel = playerData.playerMaxLevel;
            playerData.currentExp = playerData.maxExp;
            return; 
        }
        
        playerData.currentExp = playerData.minExp; 
        experianceManager.playerExpBar.maxValue = playerData.maxExp; 
        experianceManager.playerExpBarBack.maxValue = playerData.maxExp;
    }
}
