using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;


namespace Enemy
{
    public class EnemyHealthbar : MonoBehaviour
    {
        [SerializeField] SO_EnemyData _enemyData;
        private EnemyHealthManager _enemyHealthManager;
        
        [SerializeField] private Slider healthbarSlider;
        [SerializeField] private Slider healthbarSliderBack;
        private float _lerpSpeed = 0.05f;
        
        [Header("UI Text Elements")]
        [SerializeField] private TMP_Text currentHealth;
        [SerializeField] private TMP_Text MaxHealth;

        private void Start()
        {
            healthbarSlider.maxValue = _enemyData.GetEnemyMaxHealth;
            healthbarSliderBack.maxValue = healthbarSlider.maxValue;
        }

        void Update()
        {
            currentHealth.text = _enemyData.GetEnemyHealth.ToString();
            MaxHealth.text = _enemyData.GetEnemyMaxHealth.ToString();
            
            //slider code, do not touch
            if (healthbarSlider.value != _enemyData.GetEnemyHealth){
                healthbarSlider.value = _enemyData.GetEnemyHealth;
            }

            if (healthbarSlider.value != healthbarSliderBack.value) {
                healthbarSliderBack.value = Mathf.Lerp(healthbarSliderBack.value, _enemyData.GetEnemyHealth, _lerpSpeed); 
            }
        }
        
        public void UpdateEnemyHealth()
        {
            healthbarSlider.maxValue = _enemyData.GetEnemyMaxHealth;
            healthbarSlider.value = _enemyData.GetEnemyHealth;
            healthbarSliderBack.value = _enemyData.GetEnemyHealth;
        }
    }
}
