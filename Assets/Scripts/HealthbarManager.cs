using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarManager : MonoBehaviour
{
    [SerializeField] public float maxValue;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider healthBar2;
    
    
    
    void Start()
    {
        healthBar.maxValue = maxValue;
        healthBar2.maxValue = maxValue; 
    }
    
    void Update()
    {
         
    }
}
