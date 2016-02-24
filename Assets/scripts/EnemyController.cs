using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private GameObject enemyTarget;
	private GameObject enemySpawnPoint;

	private GameManager gameManager;


	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject EnemyTarget {
				get {
						return enemyTarget;
				}
				set {
						enemyTarget = value;
				}
		}

	public GameObject EnemySpawnPoint {
				get {
						return enemySpawnPoint;
				}
				set {
						enemySpawnPoint = value;
				}
		}

	public GameManager GameManager {
		get {
			return gameManager;
		}
	}
}
