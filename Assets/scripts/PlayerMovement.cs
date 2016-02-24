using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	private Rigidbody playerRigidbody;
	public float speed;
	private Vector3 moveDirection = Vector3.zero;
	private Animation glove;
	private bool enableMovement;
	private bool enableRotation;
	private int playerNumber;

	// Use this for initialization
	void Start (){
			playerRigidbody = GetComponent<Rigidbody> ();
			glove = GetComponentInChildren<Animation> ();
			playerNumber = GetComponent<PlayerController> ().getPlayerNumber();
	}

	// Update is called once per frame
	void Update (){
			playerRotation ();
			playerPunch ();
	}

	void FixedUpdate (){
			playerMovement ();
	}

	#region controller controls
	// Controls for player movement Multiplayer Xbox Controller--------------------------------------------------------------------------------------------//

	// Move player with left joystick
	void playerMovement (){	
		if (enableMovement) {
			moveDirection = new Vector3 (Input.GetAxis ("Player" + playerNumber + "_Horizontal"), 0, Input.GetAxis ("Player"+ playerNumber + "_Vertical"));
			playerRigidbody.MovePosition (playerRigidbody.position + moveDirection * Time.deltaTime * speed);
		}
	}

	// rotate player with right joystick
	void playerRotation (){		
		float horizontalLook = Input.GetAxis ("Player" + playerNumber + "_HorizontalLook");
		float veritcalLook = Input.GetAxis ("Player" + playerNumber + "_VerticalLook");

		if (enableRotation && horizontalLook != 0 || enableRotation && veritcalLook!= 0) {
			Vector3 rotationDirection = new Vector3(horizontalLook, veritcalLook, 0);
			transform.rotation = Quaternion.Euler (new Vector3 (0, (Mathf.Atan2 (rotationDirection.y, rotationDirection.x) * Mathf.Rad2Deg) + 90, 0));
		}
	}

	// plays the punch animation and disables the movement and rotation of the player until the punch is finished
	void playerPunch (){
		if (Input.GetAxis ("Player" + playerNumber + "_Trigger") != 0) {
			playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
			enableMovement = false;
			enableRotation = false;
			glove.GetComponent<Animation>().Play ("punch");
		}
		
		if (!glove.GetComponent<Animation>().IsPlaying ("punch")) {
			playerRigidbody.constraints = RigidbodyConstraints.None;
			playerRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			enableMovement = true;
			enableRotation = true;
		}
	}
	#endregion

	#region keyboard and mouse controls
	// Controls for Keyboard and mouse, single player ------------------------------------------------------------------------------------------------------//
	
	//rotate character based on mouse location
	void mouseRotation (){		
		if (enableRotation) {
			Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
			Vector3 dir = Input.mousePosition - objectPos;
			transform.rotation = Quaternion.Euler (new Vector3 (0, (Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg) * -1 + 90, 0));
		}
	}
	
	// move character around the screen using Arrow Keys or WASD
	void movement (){	
		if (enableMovement) {
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			playerRigidbody.MovePosition (playerRigidbody.position + moveDirection * Time.deltaTime * speed);
		}
	}
	
	// plays the punch animation and disables the movement and rotation of the player until the punch is finished
	void punch (){
		if (Input.GetButton("Fire1")) {
			playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
			enableMovement = false;
			enableRotation = false;
			glove.GetComponent<Animation>().Play ("punch");
		}
		
		if (!glove.GetComponent<Animation>().IsPlaying ("punch")) {
			playerRigidbody.constraints = RigidbodyConstraints.None;
			playerRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			enableMovement = true;
			enableRotation = true;
		}
	}

	#endregion
}
