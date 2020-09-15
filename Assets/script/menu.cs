using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public GameObject canvas;
    public GameObject credits;

    void Start()
    {
        Time.timeScale = 0;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            canvas.SetActive(true);
            Time.timeScale = 0;
            GameObject button = GameObject.Find("Start Game");
            button.GetComponentInChildren<UnityEngine.UI.Text>().text = "Play";
        }
    }
    public void play()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        credits.SetActive(false);
    }

    public void credit()
    {
        //lancer scene suivante
        credits.SetActive(true);
        canvas.SetActive(false);
    }

    public void back_to_menu()
    {
        //lancer scene suivante
        canvas.SetActive(true);
        credits.SetActive(false);
    }

}
