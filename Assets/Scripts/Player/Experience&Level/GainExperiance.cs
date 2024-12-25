using UnityEngine;

public class GainExperiance : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] EXPManager experianceManager;
    
    public void GainExperiancePoints(float expGain)
    {
        if (playerData == null || experianceManager == null)
        {
            Debug.LogError("PlayerData or EXPManager reference is not assigned.");
            return;
        }

        playerData.currentExp += expGain;
        Debug.Log($"You gained {expGain} EXP");

        if (playerData.currentExp >= playerData.maxExp)
        {
            playerData.currentExp -= playerData.maxExp;
            playerData.playerLevel++;

            if (playerData.playerLevel >= playerData.playerMaxLevel)
            {
                playerData.playerLevel = playerData.playerMaxLevel;
                playerData.currentExp = playerData.maxExp;
                return;
            }
        }

        experianceManager.playerExpBar.maxValue = playerData.maxExp;
        experianceManager.playerExpBarBack.maxValue = playerData.maxExp;
        //experianceManager.UpdateEXPDisplay();
    }
}
