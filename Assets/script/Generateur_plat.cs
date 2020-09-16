using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generateur_plat : MonoBehaviour
{
    void Start()
    {
        GameObject prefab = Resources.Load("plateforme_basique") as GameObject;
        for (int i =0; i<10;i++){
            GameObject go = Instantiate(prefab) as GameObject;
            go.transform.position=new Vector3(gameObject.transform.position.x + 9,gameObject.transform.position.x + i*5,0);
            go.transform.parent = gameObject.transform;
        }
    }
}
