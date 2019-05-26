using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlace : MonoBehaviour {
    public Transform HandLeft;
    public Transform HandRight;
    [SerializeField] private MeleeWeapon defaultWeaponPerfab;
    [SerializeField] private MeleeWeapon startedWeaponPrefab;
    private TakeWeaponButton takeWeaponButton;
    internal MeleeWeapon[] meleeWeapons;
    
    public Animator Ch_animator { get; private set; }
    public MeleeWeapon StartedWeaponPrefab { get { return startedWeaponPrefab; } set { startedWeaponPrefab = value; } }


    private void Start()
    {
        Player player = GetComponent<Player>();
        if (player != null)
        {
            takeWeaponButton = FindObjectOfType<TakeWeaponButton>();
            takeWeaponButton.SwapWeaponEvent += SwapWeapon;
        }
        Ch_animator = GetComponent<Animator>();
        InitWeapon();
    }

    private void SwapWeapon(MeleeWeapon meleeWeapon)
    {
        CreateWeapon(meleeWeapon);
    }

    private void CreateWeapon(MeleeWeapon weapon)
    {
        WeaponPlace weaponPlace = GetComponentInChildren<WeaponPlace>();
        meleeWeapons = new MeleeWeapon[weapon.hand.Length];
        weapon.transform.position = Vector3.zero;
        for (int i = 0; i < meleeWeapons.Length; i++)
        {
            if (weapon.hand[i] == Hand.Left)
                meleeWeapons[i] = Instantiate(weapon, weaponPlace.HandLeft);
            if (weapon.hand[i] == Hand.Right)
                meleeWeapons[i] = Instantiate(weapon, weaponPlace.HandRight);
        }
        MeleeWeaponColliderEnabled(false);
        //устанавливаю одной рукой нести или двумя
        if (weapon.weaponType == MeleeWeaponType.OneHanded)
        {
            CharacterAnimController.MeleeOneHandedWeapon(Ch_animator, true);
        }
        else if (weapon.weaponType == MeleeWeaponType.TwoHanded)
        {
            CharacterAnimController.MeleeOneHandedWeapon(Ch_animator, false);
        }
    }

    private void InitWeapon()
    {
        if (startedWeaponPrefab == null)
            CreateWeapon(defaultWeaponPerfab);
        else CreateWeapon(startedWeaponPrefab);
    }

    private void MeleeWeaponColliderEnabled(bool value)
    {
        foreach (var i in meleeWeapons)
            i.gameObject.GetComponent<Collider>().enabled = value;
    }
    //события на анимации
    public void AttackStartEvent()
    {
        MeleeWeaponColliderEnabled(true);
    }

    public void AttackStopEvent()
    {
        MeleeWeaponColliderEnabled(false);
    }
}

