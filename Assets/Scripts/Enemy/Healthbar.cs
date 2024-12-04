using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider healthbarSlider;
    [SerializeField] private Slider healthbarSliderBack;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float health;
    private float lerpSpeed = 0.05f;
    
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (healthbarSlider.value != health){
            healthbarSlider.value = health;
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            takeDamage(10);
        }

        if (healthbarSlider.value != healthbarSliderBack.value) {
            healthbarSliderBack.value = Mathf.Lerp(healthbarSliderBack.value, health, lerpSpeed); 
        }
    }

    void takeDamage(float damage)
    {
        health -= damage;
    }
}
