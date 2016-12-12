using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player; /* To get player's position in space */

	private Vector3 offset; /* To store camera offset */

	// Use this for initialization
	void Start () {

		offset = transform.position - player.transform.position;
		
	}
	
	// Update is called once per frame
	void LateUpdate () { /* Runs after update */

		transform.position = player.transform.position + offset; /*Add offset on every move */
		
	}
}
