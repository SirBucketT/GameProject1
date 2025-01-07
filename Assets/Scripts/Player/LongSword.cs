using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class LongSword : MonoBehaviour
{
    [SerializeField] private Collider _weaponCollider;
    
    [SerializeField]AudioSource memeMagic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisableWeaponCollision();
    }

    // Update is called once per frame
    void Update()
    {

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

    internal void DisableWeaponCollision()
    {
        if (_weaponCollider)
        {
            _weaponCollider.enabled = false;
        }
    }

    // public void OnEnable()
    // {
    //     EnableWeaponCollision();
    // }
    //
    // public void OnDisable()
    // {
    //     DisableWeaponCollision();
    // }


}