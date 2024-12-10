using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyDataSO", order = 1)]
    public class SOEnemyData : ScriptableObject
    { 
        private string _enemyName;
        private int _enemyHealth; 
        private int _enemyDamage; 
        private bool _enemyIsAlive; 
   
        public string EnemyName => _enemyName;
        public int EnemyHealth => _enemyHealth;
        public int EnemyDamage => _enemyDamage;
        public bool EnemyIsAlive => _enemyIsAlive;
      
    } 
    