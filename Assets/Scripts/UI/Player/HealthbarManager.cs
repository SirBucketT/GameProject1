using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;
using UI.Player;

public class HealthbarManager : MonoBehaviour
{ 
    public PlayerData playerData;
    public MenuScript MenuScript;
    
    [SerializeField] private Slider playerHealthbar; 
    [SerializeField] private Slider playerHealthbarBackSlider;
    private readonly float _lerpSpeed = 0.05f;
    
    [SerializeField] private TMP_Text currentHealth;
    [SerializeField] private TMP_Text maxMpDisplay;
    
    void Start()
    {
        playerData.currentHealth = playerData.maxHealth;
        playerData.currentHealth = playerData.maxHealth;
        maxMpDisplay.text = playerData.maxHealth.ToString();
    }

    void Update()
    {
        currentHealth.text = playerData.currentHealth.ToString();
        maxMpDisplay.text = playerData.maxHealth.ToString();
        
        //slider code, do not touch
        if (playerHealthbar.value != playerData.currentHealth){
            playerHealthbar.value = playerData.currentHealth;
        }
        if (playerHealthbar.value != playerHealthbarBackSlider.value) {
            playerHealthbarBackSlider.value = Mathf.Lerp(playerHealthbarBackSlider.value, playerData.currentHealth, _lerpSpeed); 
        }

        if (playerData.currentHealth <= 0)
        {
            playerData.currentHealth = 0;
            MenuScript.gameOverMenuUI.SetActive(true);
        }
        
    }
    
    
    public void UpdateHealthBarMaxValue()
    {
        playerHealthbar.maxValue = playerData.maxHealth;
        playerHealthbar.value = playerData.currentHealth;
        playerHealthbarBackSlider.value = playerData.currentHealth;
    }

}
