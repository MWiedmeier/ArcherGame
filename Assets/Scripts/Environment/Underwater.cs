using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Underwater : MonoBehaviour {

	public Color underWater;
	public Image waterImage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		
		Debug.Log ("Underwater");
		waterImage.color = underWater;

	}
	
	void OnTriggerExit(Collider other){

		Debug.Log ("Above Water");
		waterImage.color = Color.clear;
	}
}
