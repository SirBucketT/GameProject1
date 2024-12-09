using UnityEngine;

public class EnemyController : MonoBehaviour
{
   
    public SOEnemyData enemyData;
    void Start()
    {
      
        Debug.Log($"Enemy: {enemyData.EnemyName}, Health: {enemyData.EnemyHealth}");
    }

    void Update()
    {
       
        if (enemyData.EnemyIsAlive)
        {
            enemyData.TakeDamage(10);
            Debug.Log($"Enemy Health: {enemyData.EnemyHealth}");

            if (!enemyData.EnemyIsAlive)
            {
                Debug.Log($"{enemyData.EnemyName} has died.");
            }
        }
    }
    
}