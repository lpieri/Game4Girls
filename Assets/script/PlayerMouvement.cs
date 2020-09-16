using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
	public float moveSpeed;
	public Rigidbody2D rigidBody;
	public GameObject gameOver;
	private Vector3 velocity = Vector3.zero;
	private bool isGrounded;
	private float horizontalMovement = 0;
	private int sens = 1;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }

	void FixedUpdate() {
		MovePlayer(this.horizontalMovement);
	}

	void MovePlayer(float _horizontalMovement) {
		Vector3 targetVelocity = new Vector2(_horizontalMovement, rigidBody.velocity.y);
		rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, .05f);
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "sol"){
			//meurt
			Time.timeScale = 0;
			gameOver.SetActive(true);
		}
		else if (coll.gameObject.tag == "mur"){
			//se tourne
			this.sens = this.sens * -1;
			this.horizontalMovement = this.horizontalMovement * -1;
			gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
		}
		else if (coll.gameObject.tag == "plateform"){
			//marche
			this.horizontalMovement = moveSpeed * Time.deltaTime * this.sens;
			//if platformcrack wait 2sec puis destroy() and if ice vitess++
			if(coll.gameObject.GetComponent<SpriteRenderer>().sprite.name == "platform_crack"){
				Destroy(coll.gameObject, 1);
			}else if(coll.gameObject.GetComponent<SpriteRenderer>().sprite.name == "platform_ice"){
				this.horizontalMovement = this.horizontalMovement * 1.2F;
			}
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "plateform"){
			//tombe
			this.horizontalMovement = 0;
		}
	}
}
