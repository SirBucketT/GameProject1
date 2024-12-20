using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private TakeDamageManager _takeDamageManager;
    private float playerHealth;
    [SerializeField] PlayerData _playerData;

    public void PlayerTakeDamage(int damage)
    {
        _playerData.currentHealth -= damage;
        if (_playerData.currentHealth <= 0)
        {
            _playerData.currentHealth = 0;
            // PlayerDeathAnimation();
        }
    }

    // private void PlayerDeathAnimation()
    // {
    //     anim.SetTrigger("Death");
    // }
}
