using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bow : MonoBehaviour {

	public GameObject arrowPrefab;
	public GameObject arrowRainPrefab;

	public Collider origin;
	public float force;
	public float maxForce;
	float arrowForce;
	public Slider drawPower;


	//Cool down time in ms
	public float fireCoolDown = 1.0f;
	float lastShotTime = 0;
	float drawStartTime;
	float drawTotalTime;
	bool isPulling;

	//Script Variables
	BowMovement bowMovement;
	Quiver quiver;

	void Awake(){

		bowMovement = GetComponentInChildren<BowMovement> ();
		quiver = GetComponent<Quiver> ();

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (0)) {

			if (!isPulling && fireCoolDown < Time.time - lastShotTime) {

				startPulling ();

			} else {

				arrowForce = force * (Time.time - drawStartTime);
				if (arrowForce > maxForce)
					arrowForce = maxForce;
				drawPower.value = arrowForce / maxForce;

			}
		} else {

			if(isPulling){

				if(fireCoolDown < Time.time - lastShotTime){
					this.stopPulling();
				}else{
					isPulling = false;
					bowMovement.bowReleased();
				}
			}
		}

	}

	private void startPulling()
	{
		bowMovement.bowDrawn ();
		this.isPulling = true;
		this.arrowForce = 0;
		this.drawStartTime = Time.time;

	}

	private void stopPulling()
	{

		bowMovement.bowReleased ();

		this.isPulling = false;

		drawTotalTime = Time.time - drawStartTime;
		arrowForce = force * drawTotalTime;
		
		if(arrowForce > maxForce)
			arrowForce = maxForce;

		fire();
		this.lastShotTime = Time.time;

		drawPower.value = 0.0f;

	}


	private void fire()
	{
		if (quiver.hasArrows (1)) {
			GameObject arrow = spawnArrow ();
			Rigidbody rb = arrow.transform.GetComponent<Rigidbody> ();
			rb.AddRelativeForce (Vector3.forward * this.arrowForce);

			quiver.useArrow(1);
		}

	}

	private GameObject spawnArrow()
	{

		Vector3 startPosition = transform.position;
		Quaternion startRotation = transform.rotation;

		GameObject arrow = (GameObject)GameObject.Instantiate (arrowPrefab, startPosition, startRotation);
		Arrow obj = arrow.GetComponent<Arrow> ();
		Physics.IgnoreCollision (origin, obj.childCollider);

		return arrow;

	}
}
