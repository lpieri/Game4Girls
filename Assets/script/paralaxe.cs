using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralaxe : MonoBehaviour
{
    float offset;
    public float vitesse;

	void Update () 
	{
		float toMove = vitesse * Time.deltaTime;
		transform.Translate(Vector3.up*toMove, Space.World);
	}
}
