using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed; /* Public variables are editable on interface */
	public float jump_height;

	private float jump;
	private bool b_jump;
	private Rigidbody playerBody; /* To reference player's rigidbody - CAN BE PUBLIC*/

	float Jump() {
		float moveUp = 0;

		if (jump < jump_height) {
			moveUp = jump;
			jump++;
		} 

		else {
			jump = 0.0f;
			b_jump = false;
		}

		return moveUp;
	}

	void Start() { /* Runs on first frame the script is active */
		playerBody = GetComponent<Rigidbody> (); /* Get player's rigidbody */
	}

	void Update() {
		if (Input.GetKeyDown ("space") && transform.position[1] <= 0.6f && transform.position[1] >= 0.5f) {
			b_jump = true;
		}
	}

	void FixedUpdate() { /* Called before a physics calculation. Physics Code. */ 
		float moveHorizontal = Input.GetAxis ("Horizontal"); /* Gets the input for horizontal (A/D) and vertical (W/S) movement */
		float moveVertical = Input.GetAxis ("Vertical");
		float moveUp = 0.0f;

		if (b_jump == true) {
			moveUp = Jump ();
		}
			
		Vector3 movement = new Vector3 (moveHorizontal, moveUp, moveVertical);

		playerBody.AddForce (speed * movement); /* Add a force from X, Y, and Z */



	}

}
