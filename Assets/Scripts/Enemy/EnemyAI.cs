﻿using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float patrolSpeed = 2f;
	public float chaseSpeed = 0.2f;
	public float chaseWaitTime = 5f;
	public float patrolWaitTime = 1f;
	public Transform[] wayPoints;

	private EnemySight enemySight;
	private NavMeshAgent agent;
	private Transform player;
	private PlayerHealth playerHealth;
	private float chaseTimer;
	private float patrolTimer;
	private int wayPointIdex;
	private Animator anim;
	private int point = 0;
	void Awake(){

		enemySight = GetComponent<EnemySight> ();
		agent = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerHealth = player.GetComponent<PlayerHealth> ();
		anim = GetComponent<Animator> ();
		agent.destination = wayPoints [point].position;

	}

	// Update is called once per frame
	void Update () {
	
		if (enemySight.playerInSight && playerHealth.currentHealth > 0f && 1==2) {
			// Attack the player
			//Debug.Log ("1st If");

		}
		else if(enemySight.personalLastSighting != enemySight.resetPosition && playerHealth.currentHealth > 0f){ 
			// Chase the player
			//Debug.Log ("Chasing");
			Chasing ();

		}
		else{ 
			// Follow waypoints
			anim.SetFloat("Speed",2.1f);
			//Debug.Log("Waypoints")
			FollowRoute();
		}

	}

	void Chasing(){

		anim.SetFloat ("Speed", 1.1f);
		Vector3 sightingDeltaPos = enemySight.personalLastSighting - transform.position;

		Debug.Log ("SQR:" + sightingDeltaPos.sqrMagnitude);
		if (sightingDeltaPos.sqrMagnitude > 4f) {

			agent.destination = enemySight.personalLastSighting;
		}

		Debug.Log ("Remaining" + agent.remainingDistance);
		if (agent.remainingDistance < agent.stoppingDistance) {

			anim.SetFloat("Speed",0f);

			chaseTimer += Time.deltaTime;

			if (chaseTimer >= chaseWaitTime) {

				//Reset the personal last sighting for the enemy
				Debug.Log("I Give Up!");
				enemySight.personalLastSighting = enemySight.resetPosition;
				chaseTimer = 0f;
				agent.destination = wayPoints[point].position;

			}

		} else {

			chaseTimer = 0f;

		}

	}

	void FollowRoute(){

		if (agent.remainingDistance < 3) {
			point++;
			Debug.Log(point);
			agent.destination = wayPoints[point].position;
		}

	}
}
