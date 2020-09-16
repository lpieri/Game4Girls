using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag_n_drop : MonoBehaviour
{
    private bool isDragging;
    private bool hasBeenDragged;

    public void OnMouseDown(){
        isDragging = true;
    }

    public void OnMouseUp(){
        isDragging = false;
        hasBeenDragged = true;
    }

    void Update()
    {
        if(isDragging && !hasBeenDragged){
            //do some things
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }
}
