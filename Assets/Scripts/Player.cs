using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {

    public static Player Instance { get; set; }

    [SerializeField] private float speedMove;
	[SerializeField] private float speedGravity = 20f;
    [SerializeField] private float _radiusFindEnemy;
    [SerializeField] private float distanceAttackHand;

    private CharacterController ch_controller;
    private float gravityForce;
	private Vector3 moveVector;
	
	public Animator Ch_animator { get; private set; }

    private Enemy _enemy;
    private Gun gun = null;


    private void Start()
	{
        Instance = this;
        ch_controller = GetComponent<CharacterController>();
        Ch_animator = GetComponent<Animator>();
    }


    private void Update()
	{
		CharacterMove ();
		GamingGravity ();
        //AttackEnemy();
    }






    

	private void CharacterMove()
	{
		moveVector = Vector3.zero;
        moveVector.x = MobileController.Horizontal;
        moveVector.z = MobileController.Vertical;
        //moveVector.x = Input.GetAxis("Horizontal");
        //moveVector.z = Input.GetAxis("Vertical");



        if (moveVector.x != 0 || moveVector.z != 0)
        {
            CharacterAnimController.Walk(Ch_animator, true);
            CharacterAnimController.SpeedWalk(Ch_animator, Mathf.Abs(moveVector.x) + Mathf.Abs(moveVector.z));
        }
        else CharacterAnimController.Walk(Ch_animator, false);

        float angle = Vector3.Angle (Vector3.forward, moveVector);
		if (angle > 1f || angle == 0) 
		{
			Vector3 direct = Vector3.RotateTowards (transform.forward, moveVector, speedMove, 0.0f);
			transform.rotation = Quaternion.LookRotation (direct);
		}

        moveVector.y = gravityForce;

        ch_controller.Move (moveVector * speedMove * Time.deltaTime);

    }

	private void GamingGravity()
	{
		if (!ch_controller.isGrounded) {
			gravityForce -= speedGravity * Time.deltaTime;
		} else
			gravityForce = -1;
	}

    private void AttackEnemy()
    {
        float distanceToEnemy;

        if (_enemy == null || gun == null)
        {
            _enemy = FindNearestEnemy();
        }
        if(_enemy != null)
        {
            distanceToEnemy = Vector3.Distance(_enemy.transform.position, transform.position);
            if (distanceToEnemy > _radiusFindEnemy)
            {
                _enemy = null;
            }
            //if (distanceToEnemy <= distanceAttackHand)
            //{
            //    CharacterAnimController.AttackHand(ch_animator);
            //    foreach (var i in meleeWeapons)
            //        i.gameObject.SetActive(true);
            //}
            //else
            //    foreach (var i in meleeWeapons)
            //        i.gameObject.SetActive(false);
            //Debug.DrawLine(_enemy.gameObject.transform.position, Vector3.up, Color.green, 10);
        }
    }

    private Enemy FindNearestEnemy()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        float minDistance = _radiusFindEnemy;
        Enemy nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if (distance <= minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }
        return nearestEnemy;
    }
}
