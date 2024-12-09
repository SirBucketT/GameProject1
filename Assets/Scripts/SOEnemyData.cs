using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyDataSO", order = 1)]
    public class SOEnemyData : ScriptableObject
    { 
      [SerializeField] private string _enemyName;
      [SerializeField] private int _enemyHealth; 
      [SerializeField] private int _enemyDamage; 
      [SerializeField] private bool _enemyIsAlive; 
      [SerializeField] private Texture _enemyTexture;
      [SerializeField] private Texture2D _enemyImage;
        public string EnemyName => _enemyName;
        public int EnemyHealth => _enemyHealth;
        public int EnemyDamage => _enemyDamage;
        public bool EnemyIsAlive => _enemyIsAlive;
        public Texture EnemyTexture => _enemyTexture;
        public Texture2D EnemyImage => _enemyImage;
    } 
    