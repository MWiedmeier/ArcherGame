using UnityEngine;
using System.Collections;

public class TeleportArrow : MonoBehaviour {

	void Start () {
		

	}
	
	void OnCollisionEnter(Collision collision)
	{
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			player.transform.position = transform.position+new Vector3(0,2,0);
			
	}
		
}
	
