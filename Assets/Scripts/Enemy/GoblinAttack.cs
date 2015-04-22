using UnityEngine;
using System.Collections;

public class GoblinAttack : MonoBehaviour {

	public int damage = 10;
	public float attackCoolDown = 3f;

	Animator anim;
	GameObject player;
	PlayerHealth playerHealth;
	GoblinHealth goblinHealth;
	bool playerInRange;
	float timer;

	// Use this for initialization
	void Awake () {
	
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
		goblinHealth = GetComponent<GoblinHealth> ();
		anim = GetComponent<Animator> ();

	}

	void OnTriggerEnter(Collider other){

		Debug.Log ("Trigger Enter");
		if (other.gameObject == player) {
			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject == player) {
			playerInRange = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (timer >= attackCoolDown && playerInRange && goblinHealth.currentHealth > 0) {
			Attack();
		}
	
	}

	void Attack(){

		timer = 0f;

		anim.SetTrigger ("Attack");

		if(playerHealth.currentHealth > 0){
			playerHealth.TakeDamage(damage);
		}
	}


}
