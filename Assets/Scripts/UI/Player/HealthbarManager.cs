using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;
using UI.Player;

public class HealthbarManager : MonoBehaviour
{ 
    public HPManager HpData;
    
    [SerializeField] private Slider playerHealthbar; 
    [SerializeField] private Slider playerHealthbarBackSlider;
    private readonly float _lerpSpeed = 0.05f;
    
    [SerializeField] private TMP_Text currentHealth;
    [SerializeField] private TMP_Text maxMpDisplay;
    
    void Start()
    { 
        HpData.maxHP = 100;
        
        HpData.currentHP = HpData.maxHP;
        maxMpDisplay.text = HpData.maxHP.ToString();
    }

    void Update()
    {
        currentHealth.text = HpData.currentHP.ToString();
        
        //slider code, do not touch
        if (playerHealthbar.value != HpData.currentHP){
            playerHealthbar.value = HpData.currentHP;
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            HpData.PlayerTakeDamage(10);
        }
        if (playerHealthbar.value != playerHealthbarBackSlider.value) {
            playerHealthbarBackSlider.value = Mathf.Lerp(playerHealthbarBackSlider.value, HpData.currentHP, _lerpSpeed); 
        }

        if (HpData.currentHP <= 0)
        {
            HpData.currentHP = 0;
        }
        
    }
    
    
    public void UpdateHealthBarMaxValue()
    {
        playerHealthbar.maxValue = HpData.maxHP;
        playerHealthbar.value = HpData.currentHP;
        playerHealthbarBackSlider.value = HpData.currentHP;
    }

}
