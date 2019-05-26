using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class TakeWeaponButton : MonoBehaviour, IPointerClickHandler
{
    MeleeWeapon meleeWeapon;
    public Action<MeleeWeapon> SwapWeaponEvent;

    private void Start()
    {
        foreach (MeleeWeapon meleeWeapon in FreeWeapons.Instance.weapons)
        {
            meleeWeapon.WeaponInPlayerRangeEvent += EnableButton;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (SwapWeaponEvent != null && meleeWeapon != null)
        {
            gameObject.SetActive(false);
            SwapWeaponEvent(meleeWeapon);
            meleeWeapon.WeaponInPlayerRangeEvent -= EnableButton;
            FreeWeapons.Instance.weapons.Remove(meleeWeapon);
            Destroy(meleeWeapon.gameObject);
        }
    }

    private void EnableButton(bool value, MeleeWeapon weapon)
    {
        meleeWeapon = weapon;
        gameObject.SetActive(value);
    }
}
