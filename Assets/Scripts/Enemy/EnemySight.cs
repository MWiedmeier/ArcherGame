using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {

	public float fieldOfViewAngle = 110f;
	public bool playerInSight;
	public Vector3 personalLastSighting;
	public Vector3 resetPosition = new Vector3(1000f,1000f,1000f);

	private NavMeshAgent nav;
	private Animator anim;
	private GameObject player;
	private PlayerHealth playerHealth;
	private Vector3 previousSighting;
	private SphereCollider col;

	void Awake(){

		nav = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		col = GetComponent<SphereCollider> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();


		//Set the personal and previous sightings to the reset position
		personalLastSighting = resetPosition;
		previousSighting = resetPosition;

	}

	void Update(){

		if (playerInSight) {


		} else {


		}

	}

	void OnTriggerStay(Collider other){

		if (other.gameObject == player) {

			playerInSight = false;
			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);

			if(angle < fieldOfViewAngle * 0.5f){

				RaycastHit hit;

				if(Physics.Raycast(transform.position + transform.up,
				                   direction.normalized,
				                   out hit,
				                   col.radius)){

					if(hit.collider.gameObject == player){

						//Debug.Log("I see You");
						playerInSight = true;
						personalLastSighting = player.transform.position;
					}

				}

			}

		}
	}

}
