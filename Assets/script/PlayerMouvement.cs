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

	void FixedUpdate() {
		isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
		float horizontalMovement = 0;
		if (isGrounded) {
			horizontalMovement = moveSpeed * Time.deltaTime;
		} else {
			horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
		}
		MovePlayer(horizontalMovement);
	}

	void MovePlayer(float _horizontalMovement) {
		Vector3 targetVelocity = new Vector2(_horizontalMovement, rigidBody.velocity.y);
		rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, .05f);
	}
}
