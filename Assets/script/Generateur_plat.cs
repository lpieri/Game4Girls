using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generateur_plat : MonoBehaviour
{
    private GameObject prefab;
    private GameObject prefab_KC;
    private GameObject prefab_Glace;
    private GameObject go;
    private int i = 0;

    void Start()
    {
        this.prefab = Resources.Load("plateforme_basique") as GameObject;
        this.prefab_KC = Resources.Load("plateforme_KC") as GameObject;
        this.prefab_Glace = Resources.Load("plateforme_Glace") as GameObject;
    }

    void Update(){
        float espacement = 0F;
        if (this.i < 10){
            espacement = 2F;
            go = Instantiate(this.prefab) as GameObject;
        }
        else if (this.i  >= 10 && this.i < 40){
            espacement = 2.2F;
            go = Instantiate(getRandomPrefab(2)) as GameObject;
        }
        else if(this.i >= 40 && this.i < 55){
            espacement = 2.4F;
            go = Instantiate(getRandomPrefab(3)) as GameObject;
        }else if(this.i >= 55 && this.i < 80){
            espacement = 2.6F;
            go = Instantiate(getRandomPrefab(3)) as GameObject;
        }else{
            espacement = 2.8F;
            go = Instantiate(getRandomPrefab(3)) as GameObject;
        }
        go.transform.position = new Vector3(gameObject.transform.position.x + 10F,gameObject.transform.position.y - this.i*espacement,0);
        go.transform.parent = gameObject.transform;
        this.i++;
    }


    GameObject getRandomPrefab(int j){
        int ran = Random.Range(0, 100);

        if (j == 2){
            if (ran >= 0 && ran < 65){
                return this.prefab;
            }else{
                return this.prefab_KC;
            }
        }
        else{
            if (ran >= 0 && ran < 40){
                return this.prefab;
            }else if (ran >= 40 && ran < 75){
                return this.prefab_KC;
            }else{
                return this.prefab_Glace;
            } 
        }
    }
}
