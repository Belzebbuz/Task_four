using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class AttackController
{
    public static void Attack(this WeaponPlace weaponPlace)
    {
        if (weaponPlace.meleeWeapons.Length != 0)
        {
            if (weaponPlace.meleeWeapons.Last().weaponType == MeleeWeaponType.TwoHanded)
                CharacterAnimController.AttackHand(weaponPlace.Ch_animator);
            else if (weaponPlace.meleeWeapons.Last().weaponType == MeleeWeaponType.OneHanded)
                CharacterAnimController.AttackPalkoi(weaponPlace.Ch_animator);
        }
    }
}
