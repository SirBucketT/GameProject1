using System;
using Unity.VisualScripting;
using UnityEngine;

public class LongSword : MonoBehaviour
{
    private Collider _weaponCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisableWeaponCollision();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void EnableWeaponCollision()
    {
        if (_weaponCollider)
        {
            _weaponCollider.enabled = true;
        }
    }

    private void DisableWeaponCollision()
    {
        if (_weaponCollider)
        {
            _weaponCollider.enabled = false;
        }

    }

    public void OnEnable()
    {
        EnableWeaponCollision();
    }

    public void OnDisable()
    {
        DisableWeaponCollision();
    }


}
