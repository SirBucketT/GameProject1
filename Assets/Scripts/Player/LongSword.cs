using System;
using Unity.VisualScripting;
using UnityEngine;

public class LongSword : MonoBehaviour
{
    [SerializeField] private Collider _weaponCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisableWeaponCollision();
        Debug.Log("potato disabled");
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
        }
        Debug.Log("potato Enabled");
    }

    internal void DisableWeaponCollision()
    {
        if (_weaponCollider)
        {
            _weaponCollider.enabled = false;
        }
        Debug.Log("potato disabled");
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