using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

	// Variables for Movement
	public float movementInterval = 10F;
	private float movementTimeLeft;
	private int rand1;
	private int rand2;

	// Variables for re sizing
	public float shinkInterval = 0.2F;
	private float shrinkTimeLeft;


	private float sideA;
	private float lightRadius;
	private float angleB;		

	// Use this for initialization
	void Start () {
		movementTimeLeft = movementInterval;
	}
	
	// Update is called once per frame
	void Update () {
		lightMovement();
		lightShrinking ();

	}

	private void lightMovement(){
		movementTimeLeft -= Time.deltaTime;
		if (movementTimeLeft < 0.0F) {
			movementTimeLeft = movementInterval;
			rand1 = Random.Range (-1, 2);
			rand2 = Random.Range (-1, 2);
		}
		transform.position += new Vector3 (rand1, 0, rand2) * Time.deltaTime;
	}

	private void lightShrinking(){
		shrinkTimeLeft -= Time.deltaTime;
		if (shrinkTimeLeft < 0.0F) {
			shrinkTimeLeft = shinkInterval;
			GetComponentInChildren<Light>().spotAngle -= 1 * Time.deltaTime;
		}
		calcLightRadius ();
		navMeshRadius ();
	}	


	//find the light radius with MATH!
	private void calcLightRadius(){
		sideA = transform.GetChild(0).transform.position.y;
		angleB = GetComponentInChildren<Light>().spotAngle/2;		
		lightRadius = sideA * Mathf.Tan (angleB*Mathf.Deg2Rad);
	}

	private void navMeshRadius(){
		GetComponent<NavMeshObstacle> ().radius = lightRadius;
	}

	public float LightRadius {
		get {
			return lightRadius;
		}
	}
}
