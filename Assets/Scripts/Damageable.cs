using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour {

    [SerializeField] private int healthMax;

    public Action<Damageable> DamageEvent;
    public Action<Damageable> DieEvent;

    public int Health { get; private set; }
    public int HealthMax { get { return healthMax; } }

    private void Awake()
    {
        Health = healthMax;
    }

    public void AddDamage(int damage)
    {
        Health -= damage;
        if (DamageEvent != null)
            DamageEvent(this);

        if (Health <= 0)
        {
            if (DieEvent != null)
                DieEvent(this);
            Destroy(gameObject);
        }
    }
}
