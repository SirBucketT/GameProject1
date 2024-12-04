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
        private float lerpSpeed = 0.05f;
    
        bool isDead = false;
    
        void Start()
        {
            health = maxHealth;
        }

        void Update()
        {
            //slider code, do not touch
            if (healthbarSlider.value != health){
                healthbarSlider.value = health;
            }

            if (Input.GetKeyUp(KeyCode.Space)) {
                takeDamage(10);
            }

            if (healthbarSlider.value != healthbarSliderBack.value) {
                healthbarSliderBack.value = Mathf.Lerp(healthbarSliderBack.value, health, lerpSpeed); 
            }

        
            if (health <= 0 && !isDead)
            {
                killEnemy();
            }
        }

        void takeDamage(float damage)
        {
            health -= damage;
        }

    
        //method that will destroy the gameObject (enemy) that this script is attached to
        void killEnemy()
        {
            isDead = true; //to avoid multiple calls each frame we're implementing a bool of isDead set to true to prevent recursive call over and over again
            Destroy(gameObject);
        }
    
    }
}
