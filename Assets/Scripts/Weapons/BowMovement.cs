using UnityEngine;
using System.Collections;

public class BowMovement : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Awake () {

		anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void bowDrawn(){


		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) {

			anim.SetTrigger ("isPulling");

		}

	}

	public void bowReleased(){

		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Draw") 
			|| anim.GetCurrentAnimatorStateInfo (0).IsName ("Hold")) {

			anim.SetTrigger ("Release");

		}
	}

}
