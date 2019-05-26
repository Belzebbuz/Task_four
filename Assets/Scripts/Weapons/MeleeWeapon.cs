using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MeleeWeapon : MonoBehaviour {
    
    [SerializeField] private int damage;
        public Action<bool, MeleeWeapon> WeaponInPlayerRangeEvent;

    public MeleeWeaponType weaponType;
    public Hand[] hand;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Damageable damageableOther = other.GetComponentInParent<Damageable>();

        if (damageableOther != null)
        {
            Damageable damageable = GetComponentInParent<Damageable>();
            if(damageable != damageableOther)
                damageableOther.AddDamage(damage);
        }
    }
}

[System.Serializable]
public enum Hand { Left, Right }

[System.Serializable]
public enum MeleeWeaponType { TwoHanded, OneHanded }