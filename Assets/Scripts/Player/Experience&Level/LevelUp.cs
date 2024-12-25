using UnityEngine;

public class LevelUp : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] HealthbarManager hpBar;

    void Update()
    {
        if (playerData.currentExp >= playerData.maxExp)
        {
            playerData.currentExp = playerData.minExp;
            playerData.maxExp *= 1.3f;
            playerData.playerLevel += 1;

            playerData.maxHealth *= 1.7f;
            playerData.maxMp *= 1.8f;

            playerData.currentMp = playerData.maxMp;
            playerData.currentHealth = playerData.maxHealth;
            hpBar.UpdateHealthBarMaxValue();
        }

    }
}
