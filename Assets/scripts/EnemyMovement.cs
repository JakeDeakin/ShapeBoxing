using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour {
	private NavMeshAgent agent;
	private Transform targetLocation;

	private EnemyController enemyController;

	public GameObject closestPlayer;

	// Use this for initialization
	void Start () {
		enemyController = GetComponent<EnemyController> ();
		agent = GetComponent<NavMeshAgent> ();
		targetLocation = enemyController.EnemySpawnPoint.transform;
		agent.destination = targetLocation.position;
	}
	
	// Update is called once per frame
	void Update () {
		findClosestTarget ();
		moveToTarget ();
	}

	private void moveToTarget(){
		agent.destination = targetLocation.position;
	}

	private void findClosestTarget(){
		List<GameObject> players = enemyController.GameManager.outsidePlayers;
		GameObject player;
		Vector3 currentLocation = this.gameObject.transform.position;
		float currentDistance;
		float closestDistance = Mathf.Infinity;
		if (players.Count == 0) {
			targetLocation = enemyController.EnemySpawnPoint.transform;
		} else {
			for (int i = 0; i < players.Count; i++) {
				player = players [i];
				currentDistance = Vector3.Distance (player.transform.position, currentLocation);
				if (currentDistance < closestDistance) {
					closestPlayer = player;
					targetLocation = player.transform;
					closestDistance = currentDistance;
				}
			}
		}
	}
}
