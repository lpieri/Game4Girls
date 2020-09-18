using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEditor;

public class score : MonoBehaviour
{
    // Start is called before the first frame update
    public TextAsset content_score;
    private int actual_score;

    void Start()
    {
        actual_score = Int16.Parse(gameObject.transform.Find("score").GetComponent<UnityEngine.UI.Text>().text);
        int max_score = PlayerPrefs.GetInt("highScore", 0);
        if (actual_score > max_score){
            PlayerPrefs.SetInt("highScore", actual_score);
            max_score = actual_score;
        }
        gameObject.transform.Find("high_score").GetComponent<UnityEngine.UI.Text>().text = max_score.ToString();

        // List<int> listTmp = new List<int>();
        // string[] line_score = content_score.text.Split(new[] {"\r\n", "\r", "\n"}, System.StringSplitOptions.None);
        // //Debug.Log(line_score);
        // foreach (string line in line_score)
        // {
        //     //Debug.Log(line);
        //     try{
        //         listTmp.Add(Int16.Parse(line));
        //     }catch(Exception e) {
        //         Debug.Log("oups"+e);
        //     }
        // }
        // listTmp.Sort();
        // listTmp.Reverse();
        // // foreach (int data in listTmp)
        // // {
        // //     //Debug.Log(data);
        // // }
        // int max_score = listTmp[0];
        
        // //Debug.Log("actual_score = "+actual_score);
        // if (actual_score > listTmp[0]){
        //     //Debug.Log("youpiiii");
        //     max_score = actual_score;
        // }
        // gameObject.transform.Find("high_score").GetComponent<UnityEngine.UI.Text>().text = max_score.ToString();
        // StreamWriter writer = new StreamWriter("Assets/resources/score.csv", true);
        // writer.WriteLine(actual_score.ToString());
        // // foreach (string line in line_score)
        // // {
        // //     writer.WriteLine(line);
        // // }
        // writer.Close();

        // //Re-import the file to update the reference in the editor
        // AssetDatabase.ImportAsset("Assets/resources/score.csv");
    }


}
