using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthbarManager : MonoBehaviour
{ 
    [SerializeField] private Slider PlayerHealthbar; 
    [SerializeField] private Slider PlayerHealthbarBackSlider;
    [SerializeField] private int maxHealth = 100;
    private float health;
    private float _lerpSpeed = 0.05f;
    
    private bool _isPlayerDead;
    
    void Start()
    {
        _isPlayerDead = false;
        health = maxHealth;
    }

    void Update()
    {
        //slider code, do not touch
        if (PlayerHealthbar.value != health){
            PlayerHealthbar.value = health;
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            TakeDamage(10);
        }

        if (PlayerHealthbar.value != PlayerHealthbarBackSlider.value) {
            PlayerHealthbarBackSlider.value = Mathf.Lerp(PlayerHealthbarBackSlider.value, health, _lerpSpeed); 
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
