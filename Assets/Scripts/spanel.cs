using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class spanel : MonoBehaviour
{
    private int k;
    private Text[] txt;
    // Start is called before the first frame update
    void Start()
    {
        k=1000;
        txt = new Text[4];
        txt[0] = GameObject.Find("start").GetComponent<Text>();
        txt[1] = GameObject.Find("continue").GetComponent<Text>();
        txt[2] = GameObject.Find("option").GetComponent<Text>();
        txt[3] = GameObject.Find("exit").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) k++;
        if (Input.GetKeyDown(KeyCode.UpArrow)) k--;
        for (int i= 0 ; i<4 ;i++)
            txt[i].color = Color.gray;
        txt[k%4].color=Color.white;

        if (k%4==0 && Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene(2);
        if (k%4==3 && Input.GetKeyDown(KeyCode.Return))
            Application.Quit();
    }
}
