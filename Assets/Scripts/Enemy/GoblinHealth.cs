using UnityEngine;
using System.Collections;

public class GoblinHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public float sinkSpeed = 2.5f;

	Animator anim;
	ParticleSystem hitParticles;
	bool isDead;
	bool isSinking;
	bool isDOT;
	float timer;
	GoblinMovement goblinMovement;


	// Use this for initialization
	void Awake () {
	
		anim = GetComponent<Animator> ();

		hitParticles = GetComponentInChildren<ParticleSystem> ();
		goblinMovement = GetComponent<GoblinMovement> ();
		//Set the Goblins Current Health
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {

		if (isSinking) {
			transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
		}
	
	}

	public void TakeDamage(int amount){

		if (isDead)
			return;

		//Play hurt sound here

		//Reduce health based on player damage
		currentHealth -= amount;

		//Play Paticle Damage Effect
		hitParticles.Play ();

		if (currentHealth <= 0) {
			Death();
			StartSinking();
		}

	}

	public void TakeDOT(int amount){

		if (isDead)
			return;
		
		//Play hurt sound here
		
		//Reduce health based on player damage
		currentHealth -= amount;
		
		//Play Paticle Damage Effect
		//hitParticles.Play ();
		
		if (currentHealth <= 0) {
			Death();
			StartSinking();
		}

	}

	void Death(){

		isDead = true;
		goblinMovement.enabled = false;
		anim.SetTrigger ("GoblinDead");

	}

	public void StartSinking(){

		//We control the movement of the sinking
		GetComponent <Rigidbody> ().isKinematic = true;

		isSinking = true;

		Destroy (gameObject, 2f);
	}
}
