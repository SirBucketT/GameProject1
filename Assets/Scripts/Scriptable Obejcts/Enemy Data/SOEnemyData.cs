using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyDataSO", order = 1)]
    internal class SO_EnemyData : ScriptableObject
    { 
       [SerializeField] private string _enemyName;
       [SerializeField] private int _enemyMaxHealth;
       [SerializeField] private int _enemyHealth; 
       [SerializeField] private int _enemyDamage; 
       [SerializeField] private bool _enemyIsAlive;
       [SerializeField] private Color _enemyColor;
       [SerializeField] private Texture2D _texture;
   
        internal string GetEnemyName => _enemyName;
        internal int GetEnemyMaxHealth => _enemyMaxHealth;
        internal int GetEnemyHealth => _enemyHealth;
        internal int GetEnemyDamage => _enemyDamage;
        internal Color GetEnemyColor => _enemyColor;
        internal bool GetEnemyIsAlive => _enemyIsAlive;
    } 
    