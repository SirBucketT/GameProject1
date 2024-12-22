using UnityEngine;

public interface ITakeDamage
{
    void TakeDamage(int damageAmount);
    bool isAlive { get; }
}
