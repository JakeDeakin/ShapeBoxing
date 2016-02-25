using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public GameObject playerPrefab;
	public int numPlayers;
	private GameObject player;
	public GameObject[] playerSpawnPoints;
	public List<GameObject> players = new List<GameObject> ();
	public List<GameObject> outsidePlayers = new List<GameObject>();
	public GameObject enemyPrefab;
	public int numEnemies;
	private GameObject enemy;
	public GameObject GameLight { get; set; }
	private Vector3 gameCenter;

	// Use this for initialization
	void Start () {
		spawnPlayers (numPlayers, playerPrefab);
		spawnEnemies (numEnemies, enemyPrefab);
		GameLight = GameObject.FindGameObjectWithTag ("GameLight") as GameObject;
		gameCenter = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		gameCenter = transform.position;
		checkPlayersOutisde ();
	}

	private void spawnPlayers(int numPlayers, GameObject prefab){
		for (int i = 0; i < numPlayers; i++) {
			GameObject spawnPoint = playerSpawnPoints[i];
			Vector3 spawnPosition = spawnPoint.transform.position;
			Quaternion spawnRotation = spawnPoint.transform.rotation;
			player = Instantiate (prefab, spawnPosition, spawnRotation) as GameObject;
            player.GetComponent<PlayerController>().playerNumber = i+1;
                //setPlayerNumber(i+1);
			players.Add(player);
		}
	}

	private void spawnEnemies(int numEnemies, GameObject prefab){
		for (int i = 0; i < numEnemies; i++) {
			GameObject spawnPoint = transform.GetChild(1).transform.GetChild(i).gameObject;
			Vector3 spawnPosition = spawnPoint.transform.position;
			Quaternion spawnRotation = spawnPoint.transform.rotation;
			enemy = Instantiate(prefab, spawnPosition, spawnRotation) as GameObject;
			enemy.GetComponent<EnemyController>().EnemySpawnPoint = spawnPoint;
		}
	}

	private void checkPlayersOutisde(){
		for (int i = 0; i < players.Count; i++) {
			Vector3 playerPosition = players[i].GetComponent<Transform>().position;
			GameObject player = players[i];
			if (Vector3.Distance (playerPosition, gameCenter) > GameLight.GetComponent<LightController>().LightRadius){
				if (!outsidePlayers.Contains(player)){
					outsidePlayers.Add(player);
				}
			} else if (outsidePlayers.Contains(player)){
				outsidePlayers.Remove(player);
			}
		}
	}
}
