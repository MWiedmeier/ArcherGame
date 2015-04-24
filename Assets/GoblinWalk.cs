using UnityEngine;
using System.Collections;

public class GoblinWalk : MonoBehaviour {

	public Transform[] waypoints;
	public int point = 0;

	NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.destination = waypoints [point].position;

	}
	
	// Update is called once per frame
	void Update () {
		if (agent.remainingDistance < 5) {
			point++;
			agent.destination = waypoints[point].position;
		}
	}
}
