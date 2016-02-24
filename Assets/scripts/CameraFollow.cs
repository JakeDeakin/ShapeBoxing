using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float distance;
	public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(target.position.x, target.position.y + distance, target.position.z - 2.5f);
	}
}
