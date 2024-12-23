using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyDataSO", order = 1)]
    internal class SO_EnemyData : ScriptableObject
    { 
       [SerializeField] private string _enemyName;
       [SerializeField] private int _enemyMaxHealth;
       [SerializeField] private int _enemyHealth; 
       [SerializeField] private int _enemyDamage; 
   
        internal string GetEnemyName => _enemyName;
        internal int GetEnemyMaxHealth => _enemyMaxHealth;
        internal int GetEnemyHealth => _enemyHealth;
        internal int GetEnemyDamage => _enemyDamage;
    } 
    