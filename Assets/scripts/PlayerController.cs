using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // Boolean values for the player's state

    // Alive
    public bool playerIsAlive { get; set; }
    // Punching
    public bool playerIsPunching { get; set; }
    // Power ups
    public bool playerSpeedBoost { get; set; }
    public bool playerStrongPunch { get; set; }
    public bool playerInvulnerable {get; set; }

    // player number
    public int playerNumber {get; set; }

    public bool playerInside { get; set; }
    private GameManager gameManager;
	private LightController gameLightController;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
		gameLightController = gameManager.GameLight.GetComponent<LightController> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerIsInside();
	}
	
	public void playerIsInside(){
		if (Vector3.Distance (transform.position, gameManager.transform.position) > gameLightController.LightRadius) {
			playerInside = false;
		} else { 
			playerInside = true;
		}
	}

}
