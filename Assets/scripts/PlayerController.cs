using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Boolean values for the player's state

	// Alive
	private bool playerIsAlive;
	// Punching
	private bool playerIsPunching;
	// Power ups
	private bool playerSpeedBoost;
	private bool playerStrongPunch;
	private bool playerInvulnerable;	

	// player number
	private int playerNumber;

	private bool playerInside;
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
		print (playerInside);
	}
	
	public void setPlayerIsAlive(bool alive){
		playerIsAlive = alive;
	}

	public void setPlayerIsPunching(bool punching){
		playerIsPunching = punching;
	}

	public void setPlayerSpeedBoost(bool speedboost){
		playerSpeedBoost = speedboost;
	}

	public void setPlayerStrongPunch(bool strongpunch){
		playerStrongPunch = strongpunch;
	}

	public void setPlayerInvulnerable(bool invulnerable){
		playerInvulnerable = invulnerable;
	}

	public void setPlayerNumber(int number){
		playerNumber = number;
	}
	
	public bool getPlayerIsAlive(){
		return playerIsAlive;
	}
	
	public bool getPlayerIsPunching(){
		return playerIsPunching;
	}
	
	public bool getPlayerSpeedBoost(){
		return playerSpeedBoost;
	}
	
	public bool getPlayerStrongPunch(){
		return playerStrongPunch;
	}
	
	public bool getPlayerInvulnerable(){
		return playerInvulnerable;
	}

	public int getPlayerNumber(){
		return playerNumber;
	}

	#region New getter and setters

	public bool PlayerInside {
		get {
			return playerInside;
		}
	}

	public void playerIsInside(){
		if (Vector3.Distance (transform.position, gameManager.transform.position) > gameLightController.LightRadius) {
			playerInside = false;
		} else { 
			playerInside = true;
		}
	}

	#endregion
}
