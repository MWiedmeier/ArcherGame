using UnityEngine;
using System.Collections;

public class GoblinAttack : MonoBehaviour {
	
	public bool playerInRange;
	GameObject player;

	// Use this for initialization
	void Awake () {
	
		player = GameObject.FindGameObjectWithTag ("Player");

	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject == player) {
			Debug.Log("Player In Attack Range");
			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject == player) {
			Debug.Log("Player Leaving Attack Range");

			playerInRange = false;
		}
	}

}
