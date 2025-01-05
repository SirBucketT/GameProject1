using System;
using UnityEngine;

public class EnemyTakeDamageCooldown: MonoBehaviour
{
    [SerializeField] private float _damageCooldown = 0.5f;
    private bool _isCooldownActive = false;
    private float _cooldownTimer = 0f;

    public bool CanTakeDamage()
    {
        if (_isCooldownActive)
        {
            return false; 
        }

        _isCooldownActive = true;
        _cooldownTimer = _damageCooldown;
        return true;
    }

    private void Update()
    {
        if (_isCooldownActive)
        {
            DamageCooldownReset();
        }
    }

    private void DamageCooldownReset()
    {
        _cooldownTimer -= Time.deltaTime;
        if (_cooldownTimer <= 0f)
        {
            _isCooldownActive = false; 
        }
    }
    public float GetDamageCooldown() => _damageCooldown;
}