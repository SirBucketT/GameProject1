using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyHealthbar : MonoBehaviour
    {
        [SerializeField] private Slider healthbarSlider;
        [SerializeField] private Slider healthbarSliderBack;
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float health;
        private float _lerpSpeed = 0.05f;
    
        private bool _isDead;
    
        void Start()
        {
            _isDead = false;
            health = maxHealth;
        }

        void Update()
        {
            //slider code, do not touch
            if (healthbarSlider.value != health){
                healthbarSlider.value = health;
            }

            if (Input.GetKeyUp(KeyCode.Space)) {
                TakeDamage(10);
            }

            if (healthbarSlider.value != healthbarSliderBack.value) {
                healthbarSliderBack.value = Mathf.Lerp(healthbarSliderBack.value, health, _lerpSpeed); 
            }

        
            if (health <= 0 && !_isDead) {
                KillEnemy();
            }
        }

        void TakeDamage(float damage) {
            health -= damage;
        }

    
        //method that will destroy the gameObject (enemy) that this script is attached to
        void KillEnemy() {
            _isDead = true; //to avoid multiple calls each frame we're implementing a bool of isDead set to true to prevent recursive call over and over again
            Destroy(gameObject);
        }
    }
}
