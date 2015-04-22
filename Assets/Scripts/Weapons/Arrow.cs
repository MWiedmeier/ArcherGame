using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	public Collider childCollider;
	private bool flying = true;
	public float lifeTime;

	float startTime;

	GoblinHealth goblinHealth;

	// Use this for initialization
	void Awake () {

		startTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (flying)
		{
			this.rotate ();
		} 


		if (Time.time > startTime + lifeTime) {

			Destroy(transform.gameObject);

		}

	}

	void OnCollisionEnter(Collision collision)
	{
		if (this.flying) {

			flying = false;

			transform.position = collision.contacts[0].point;

			//Retrieve the Health of the enemy hit
			goblinHealth = collision.gameObject.GetComponent<GoblinHealth>();
			if(goblinHealth != null){
				goblinHealth.TakeDamage(50);
			}

			childCollider.isTrigger = true;

			this.transform.parent = collision.transform;

			Destroy(transform.GetComponent<Rigidbody>());
			Debug.Log("Arrow Hit");

		}

	}

	void rotate(){

		transform.LookAt (transform.position + transform.GetComponent<Rigidbody>().velocity);

	}
}
