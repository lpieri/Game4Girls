using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public GameObject canvas;
    void Start()
    {
        Time.timeScale = 0;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            canvas.SetActive(true);
            Time.timeScale = 0;
            GameObject button = GameObject.Find("play");
            button.GetComponentInChildren<UnityEngine.UI.Text>().text = "Play";
        }
    }
    public void play()
    {
        //lancer scene suivante
        canvas.SetActive(false);
    }

}
