using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public GameObject EnemyTarget { get; set; }
    public GameObject EnemySpawnPoint { get; set; }

    public GameManager GameManager { get; set; }


    // Use this for initialization
    void Start () {
		GameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
