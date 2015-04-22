using UnityEngine;
using System.Collections;

public class FireArrow : MonoBehaviour {

	public int DOT = 5;
	public int totalTicks = 5;
	public float damageTick= 1.0f;

	float timer;
	GoblinHealth enemy;

	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (enemy != null && timer > damageTick && totalTicks > 0) {

			enemy.TakeDOT(DOT);
			timer = 0;
			totalTicks-=1;

		}
	
	}

	void OnCollisionEnter(Collision collision)
	{
		enemy = collision.gameObject.GetComponent<GoblinHealth>();
		timer = 0.0f;

	}
}
