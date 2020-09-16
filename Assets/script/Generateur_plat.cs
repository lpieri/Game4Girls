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
        if (this.i < 45){
            espacement = 2F;
            go = Instantiate(this.prefab) as GameObject;
        }
        else if (this.i  >= 45 && this.i < 80){
            espacement = 2.5F;
            go = Instantiate(getRandomPrefab(2)) as GameObject;
        }
        else if(this.i >= 80 && this.i < 120){
            espacement = 3F;
            go = Instantiate(getRandomPrefab(3)) as GameObject;
        }else if(this.i >= 120 && this.i < 170){
            espacement = 3.5F;
            go = Instantiate(getRandomPrefab(3)) as GameObject;
        }else{
            espacement = 4F;
            go = Instantiate(getRandomPrefab(3)) as GameObject;
        }
        go.transform.position = new Vector3(gameObject.transform.position.x + 9,gameObject.transform.position.y - this.i*espacement,0);
        go.transform.parent = gameObject.transform;
        this.i++;
    }


    GameObject getRandomPrefab(int j){
        int ran = Random.Range(0, 100);

        if (j == 2){
            if (ran >= 0 && ran < 80){
                return this.prefab;
            }else{
                return this.prefab_KC;
            }
        }
        else{
            if (ran >= 0 && ran < 50){
                return this.prefab;
            }else if (ran >= 50 && ran < 80){
                return this.prefab_KC;
            }else{
                return this.prefab_Glace;
            } 
        }
    }
}
