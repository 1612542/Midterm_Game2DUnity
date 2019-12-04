using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class spanel : MonoBehaviour
{
    private int k;
    private Text[] txt;
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        k=1002;
        txt = new Text[6];
        txt[0] = GameObject.Find("s0").GetComponent<Text>();
        txt[1] = GameObject.Find("s1").GetComponent<Text>();
        txt[2] = GameObject.Find("s2").GetComponent<Text>();
        txt[3] = GameObject.Find("s3").GetComponent<Text>();
        txt[4] = GameObject.Find("s4").GetComponent<Text>();
        txt[5] = GameObject.Find("s5").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            k++;
            sound.Play();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            k--;
            sound.Play();
        } 
        for (int i= 0 ; i<6 ;i++)
            txt[i].color = Color.gray;
        txt[k%6].color=Color.white;

        if (k%6==0 && Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene("Round1-x");
        if (k%6==1 && Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene("Round2-x");
        if (k%6==2 && Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene("Round1-zero");
            if (k%6==3 && Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene("Round2-zero");
            if (k%6==4 && Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene("Tutorial");
        if (k%6==5 && Input.GetKeyDown(KeyCode.Return))
            Application.Quit();
    }
}
