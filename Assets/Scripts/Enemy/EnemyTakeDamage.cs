using UnityEngine;

public class EnemyController : MonoBehaviour, ITakeDamage, IInteractable
{
    private SOEnemyData enemyData;

    private int currentHealth;
    private bool isAlive;

    private void Start()
    {
        currentHealth = enemyData.EnemyHealth; 
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