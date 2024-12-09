using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyDataSO", order = 1)]
    public class SOEnemyData : ScriptableObject
    {
       [SerializeField] private string enemyName;
       [SerializeField] private int enemyHealth;
       [SerializeField] private int enemyDamage;
       [SerializeField] private bool enemyIsAlive;
       [SerializeField] private Texture enemyTexture;
       [SerializeField] private Texture2D enemyImage;
      

       private int GetEnemyHealth()
       {
           return enemyHealth;
       }

       private void ReduceEnemyHealth(int dmgAmount)
       {
           enemyHealth -= dmgAmount;
       }

       private void SetEnemyHealth(int newEnemyHealth)
       {
           enemyHealth -= newEnemyHealth;
       }
    } 
    