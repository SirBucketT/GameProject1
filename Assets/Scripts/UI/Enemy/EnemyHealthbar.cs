using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;


namespace Enemy
{
    public class EnemyHealthbar : MonoBehaviour
    {
        public EnemyData _enemyData;
        
        [SerializeField] private Slider healthbarSlider;
        [SerializeField] private Slider healthbarSliderBack;
        private float _lerpSpeed = 0.05f;
        
        [Header("UI Text Elements")]
        [SerializeField] private TMP_Text currentHealth;
        [SerializeField] private TMP_Text MaxHealth;
        [SerializeField] private int startHealth = 100;

        private void Start()
        {
            _enemyData.MaxHealth = startHealth;
            _enemyData.CurrentHealth = _enemyData.MaxHealth;
        }

        void Update()
        {
            currentHealth.text = _enemyData.CurrentHealth.ToString();
            MaxHealth.text = _enemyData.MaxHealth.ToString();
            
            //slider code, do not touch
            if (healthbarSlider.value != _enemyData.CurrentHealth){
                healthbarSlider.value = _enemyData.CurrentHealth;
            }

            if (Input.GetKeyUp(KeyCode.O)) {
                _enemyData.TakeDamage(10);
            }

            if (healthbarSlider.value != healthbarSliderBack.value) {
                healthbarSliderBack.value = Mathf.Lerp(healthbarSliderBack.value, _enemyData.CurrentHealth, _lerpSpeed); 
            }
        }
        
        public void UpdateEnemyHealth()
        {
            healthbarSlider.maxValue = _enemyData.MaxHealth;
            healthbarSlider.value = _enemyData.CurrentHealth;
            healthbarSliderBack.value = _enemyData.CurrentHealth;
        }
    }
}
