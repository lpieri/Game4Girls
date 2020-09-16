using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralaxe : MonoBehaviour
{
    float offset;
    public float vitesse;
	private int _score = 0;
	private int _coin = 0;
	private GameObject score;
	private GameObject coin;

	void Start()
    {
        this.score = GameObject.FindGameObjectWithTag("score");
		this.coin = GameObject.FindGameObjectWithTag("coin");
    }

	void Update () 
	{
		GameObject player = GameObject.Find("Player");
		float vitesseVerticalePlayer = player.GetComponent<Rigidbody2D>().velocity.y * -1;
		//Debug.Log("vitesse = "+vitesseVerticalePlayer);

		if(vitesseVerticalePlayer > 0){
			float toMove = vitesseVerticalePlayer * vitesse * Time.deltaTime;
			transform.Translate(Vector3.up*toMove, Space.World);
			this._score = this._score + 1;
			this.score.GetComponent<UnityEngine.UI.Text>().text = this._score.ToString();
		}
		else{
			float toMove = vitesse * Time.deltaTime;
			transform.Translate(Vector3.up*toMove, Space.World);
		}

		if (this._score != 0 && this._score % 100 == 0){
			this._coin = this._coin + 1;
			this.coin.GetComponent<UnityEngine.UI.Text>().text = this._coin.ToString();
		}
	}
}
