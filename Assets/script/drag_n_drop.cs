using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag_n_drop : MonoBehaviour
{
    private bool isDragging;
    private bool hasBeenDragged;

    void Start(){
        gameObject.GetComponent<Collider2D>().isTrigger = true;
    }

    public void OnMouseDown(){
        isDragging = true;
    }

    public void OnMouseUp(){
        isDragging = false;
        gameObject.GetComponent<Collider2D>().isTrigger = false;
        gameObject.transform.Find("overlay").gameObject.SetActive(false);
        hasBeenDragged = true;
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
