using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Quiver : MonoBehaviour {

	public int maxArrowCount;
	public int currentArrowCount;
	public Text arrowText;

	// Use this for initialization
	void Awake () {

		currentArrowCount = maxArrowCount;
	
	}
	
	// Update is called once per frame
	void Update () {

		arrowText.text = "Arrows: " + currentArrowCount + "/" + maxArrowCount;
	
	}

	//Add found arrows to the quiver
	public void addArrow(int arrows){

		if (currentArrowCount < maxArrowCount) {

			currentArrowCount+=arrows;

			//Check to see if youre over the max arrow count
			if(currentArrowCount > maxArrowCount){
				currentArrowCount = maxArrowCount;
			}

		} // end outter if
	}


	//Called when arrow shot, subtract amount of arrows used from quiver
	public void useArrow(int used){

		if(currentArrowCount > 0)
			currentArrowCount -= used;

	}

	//Check to see if there are enough arrows to shoot
	public bool hasArrows(int amount){

		if (currentArrowCount >= amount) {

			return true;
		}

		return false;

	}
}
