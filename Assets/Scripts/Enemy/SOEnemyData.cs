using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyDataSO", order = 1)]
    public class SO_EnemyData : ScriptableObject
    { 
       [SerializeField] private string _enemyName; 
       [SerializeField] private int _enemyHealth; 
       [SerializeField] private int _enemyDamage; 
       [SerializeField] private bool _enemyIsAlive;
       [SerializeField] private Color _enemyColor;
       [SerializeField] private Texture2D _texture;
   
        public string GetEnemyName => _enemyName;
        public int GetEnemyHealth => _enemyHealth;
        public int GetEnemyDamage => _enemyDamage;
        public Color GetEnemyColor => _enemyColor;
        public bool GetEnemyIsAlive => _enemyIsAlive;
      
    } 
    