using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour {

    [SerializeField] float attackRange;
    [SerializeField] float attakDelay;

    private NavMeshAgent navAgent;
    private Animator animator;
    private WeaponPlace weaponPlace;
    private float attackTimer;
    

    private void Start()
    {
        weaponPlace = GetComponent<WeaponPlace>();
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Walk();
        if (CheckAttackRange())
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                weaponPlace.Attack();
                attackTimer = attakDelay;
            }
        }
        else attackTimer = attakDelay;        
    }


    private bool CheckAttackRange()
    {
        float dist = Vector3.Distance(transform.position, Player.Instance.transform.position);
        return dist <= attackRange;
    }

    private void Walk()
    {
        if (Player.Instance != null)
            navAgent.SetDestination(Player.Instance.transform.position);

        if (Mathf.Approximately(navAgent.velocity.magnitude, 0f))
        {
            CharacterAnimController.Walk(animator, false);
        }
        else
        {
            CharacterAnimController.Walk(animator, true);
            float forwardSpeed = navAgent.velocity.magnitude;
            CharacterAnimController.SpeedWalk(animator, forwardSpeed);
        }
    }
}
