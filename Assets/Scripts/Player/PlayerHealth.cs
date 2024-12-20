using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private TakeDamageManager _takeDamageManager;
    private float playerHealth;
    [SerializeField] PlayerData _playerData;

    public void PlayerTakeDamage(int damage) // Ändrade från float till int
    {
        _playerData.currentHealth -= damage;
        // Debug.Log($"Player health {_playerData.currentHealth}");
    }
}
