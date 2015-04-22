using UnityEngine;
using System.Collections;

public class SpawnGoblins : MonoBehaviour {

	public GameObject goblinPrefab;
	public int maxMobCount =  20;
	public float spawnCoolDown;

	int currentMobCount;
	float timer;
	//Array with reference to all active goblins
	ArrayList goblins = new ArrayList();

	// Use this for initialization
	void Start () {

		currentMobCount = 0;
		timer = 0.0f;
	
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (currentMobCount < maxMobCount && timer > spawnCoolDown) {

			spawnGoblin();
			timer = 0.0f;

		}
	
	}

	void spawnGoblin(){

		float xPosition = Random.Range (transform.position.x - transform.localScale.x/2, 
		                                transform.position.x + transform.localScale.x/2);

		float zPosition = Random.Range (transform.position.z - transform.localScale.z/2, 
		                                transform.position.z + transform.localScale.z/2);

		Vector3 spawnPoint = new Vector3 (xPosition, transform.position.y, zPosition);
		GameObject spawn = Instantiate(goblinPrefab, spawnPoint, goblinPrefab.transform.rotation) as GameObject;
		goblins.Add (spawn);

		currentMobCount += 1;

	}
}
