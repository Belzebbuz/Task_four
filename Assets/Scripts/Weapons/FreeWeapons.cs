using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class FreeWeapons : MonoBehaviour
{
    [SerializeField] private float activeDist;
    internal List<MeleeWeapon> weapons = new List<MeleeWeapon>();

    public static FreeWeapons Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        weapons.AddRange(GetComponentsInChildren<MeleeWeapon>());

        foreach (MeleeWeapon weapon in weapons)
        {
            Collider _collider = weapon.GetComponent<Collider>();
            if (_collider != null)
                _collider.enabled = false;
        }
    }

    private void Update()
    {
        foreach (MeleeWeapon weapon in weapons)
            if (CheckWeaponInActiveDistance(weapon, Player.Instance))
            {
                ActivateButton(weapon,true);
                break;
            }
            else
                ActivateButton(weapon,false);
        
    }

    private bool CheckWeaponInActiveDistance(MeleeWeapon weapon, Player player)
    {
        float dist = Vector3.Distance(weapon.transform.position, player.transform.position);
        return dist < activeDist;
    }

    private void ActivateButton(MeleeWeapon weapon, bool value)
    {
        if (weapon != null)
        {
            if (weapon.WeaponInPlayerRangeEvent != null)
                weapon.WeaponInPlayerRangeEvent(value, weapon);
        }
        else
        {
            if (weapon.WeaponInPlayerRangeEvent != null)
                weapon.WeaponInPlayerRangeEvent(value, null);
        }
    }
}
