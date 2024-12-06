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
    [SerializeField] private float maxHealth = 100;
    private float health;
    private readonly float _lerpSpeed = 0.05f;
    
    private bool _isPlayerDead;
    
    [SerializeField] private TMP_Text currentHealth;
    [SerializeField] private TMP_Text maxMpDisplay;
    
    void Start()
    {
        health = maxHealth;
        _isPlayerDead = false;
    }

    void Update()
    {
        currentHealth.text = HpData.maxHP.ToString();
        maxMpDisplay.text = HpData.currentHP.ToString();
        
        //slider code, do not touch
        if (playerHealthbar.value != health){
            playerHealthbar.value = health;
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            TakeDamage(10);
        }
        if (playerHealthbar.value != playerHealthbarBackSlider.value) {
            playerHealthbarBackSlider.value = Mathf.Lerp(playerHealthbarBackSlider.value, health, _lerpSpeed); 
        }
        if (health <= 0 && !_isPlayerDead) {
            _isPlayerDead = true;
        //     TODO implement feature that loads game over UI elements
        }
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    void TakeDamage(float damage) {
        health -= damage;
        Debug.Log("spaceBar pressed, you lose 10 health");
        Debug.Log($"Player health: {health}");
    }

}
