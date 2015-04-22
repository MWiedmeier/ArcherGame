using UnityEngine;
using System.Collections;

public class GoblinMovement : MonoBehaviour {

	public float speed = 3f;

	float timer;
	Animator anim;
	NavMeshAgent agent;
	Transform target;

	// Use this for initialization
	void Awake () {
	
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		speed = 1.1f;
		anim.SetFloat ("Speed",speed);
		GameObject tar = GameObject.FindGameObjectWithTag ("Target");
		target = tar.transform;

	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (timer > 2.0f) {

			agent.destination = target.position;
		}
	
	}
}
