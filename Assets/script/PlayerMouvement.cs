using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
	public float moveSpeed;
	public Transform groundCheckLeft;
	public Transform groundCheckRight;
	public Rigidbody2D rigidBody;
	private Vector3 velocity = Vector3.zero;
	private bool isGrounded;
	private float horizontalMovement = 0;

	void FixedUpdate() {
		MovePlayer(this.horizontalMovement);
	}

	void MovePlayer(float _horizontalMovement) {
		Vector3 targetVelocity = new Vector2(_horizontalMovement, rigidBody.velocity.y);
		rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, .05f);
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Sol"){
			//meurt
			Debug.Log("collision avec "+ coll.gameObject.name);
		}
		else if (coll.gameObject.tag == "plateform"){
			//marche
			this.horizontalMovement = moveSpeed * Time.deltaTime;
		}
		else if (coll.gameObject.tag == "mur"){
			//se tourne
			this.horizontalMovement = this.horizontalMovement * -1;
		}
	}

	
	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "plateform"){
			//marche
			this.horizontalMovement = 0;
		}
	}
}
