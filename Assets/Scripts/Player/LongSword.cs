using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class LongSword : MonoBehaviour
{
    [SerializeField] Collider _weaponCollider;
    [SerializeField] Collider _footCollider;
    
    [SerializeField] AudioSource memeMagic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisableWeaponCollision();
        DisableFootCollision();
    }
    
    internal void EnableFootCollision()
    {
        _footCollider.enabled = true;
    }
    internal void EnableWeaponCollision()
    {
        if (_weaponCollider)
        {
            _weaponCollider.enabled = true;
            
        if (memeMagic != null)
        {
            memeMagic.Play();
        }
        }
    }

    internal void DisableFootCollision()
    {
        _footCollider.enabled = false;
    }
    internal void DisableWeaponCollision()
    {
        _weaponCollider.enabled = false;
    }
}