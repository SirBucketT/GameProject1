using UnityEngine;

public class EnemyController : MonoBehaviour, ITakeDamage, IInteractable
{
    private SO_EnemyData enemyData;

    private int currentHealth;
    private bool isAlive;

    private void Start()
    {
        currentHealth = (int)enemyData.GetEnemyHealth; 
        isAlive = true;
    }

    public void TakeDamage(int dmgAmount)
    {
        if (!isAlive) return;
        currentHealth -= dmgAmount;
        if (currentHealth <= 0)
        {
            isAlive = false;
        }
    }

    public void Interact()
    {
        void onCollisionEnter2D(Collision2D collision)
        {
            TakeDamage(5);
        }
    }
    
}