using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag_n_drop : MonoBehaviour
{
    private bool isDragging;
    private bool hasBeenDragged;
    private AudioSource blop;
    private GameObject droit ;
    private GameObject gauche;


    void Start(){
        this.droit  = gameObject.transform.Find("coté_droit").gameObject;
        this.gauche = gameObject.transform.Find("coté_gauche").gameObject;
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        droit.GetComponent<Collider2D>().isTrigger = true;
        gauche.GetComponent<Collider2D>().isTrigger = true;
        this.blop = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    public void OnMouseDown(){
        isDragging = true;
    }

    public void OnMouseUp(){
        isDragging = false;
        gameObject.GetComponent<Collider2D>().isTrigger = false;
        this.droit.GetComponent<Collider2D>().isTrigger = false;
        this.gauche.GetComponent<Collider2D>().isTrigger = false;
        gameObject.transform.Find("overlay").gameObject.SetActive(false);
        hasBeenDragged = true;
        this.blop.Play();

    }

    void Update()
    {
        if(isDragging && !hasBeenDragged){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }

    void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.name == "plafond"){
			Destroy(coll.gameObject, 1);
        }
    }
}
