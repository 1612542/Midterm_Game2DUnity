using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayControl : MonoBehaviour
{
    private List<string> listEnemy = new List<string>() { "bee", "bat", "mushroom", "flying_face", "bosscar" };
    private int numberEnemy = 0;
    private GameObject[] gameObjects;
    private GameObject player;

    void Awake() 
    {
        //foreach (string s in listEnemy)
        //{
        //    numberEnemy += GameObject.FindGameObjectsWithTag(s).lengt;
        //    GameObject.FindGameObjectWithTag(s).SetActive(false);
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        /*foreach (string s in listEnemy)
        {
            GameObject.FindGameObjectWithTag(s).SetActive(false);
        }*/
        player = GameObject.FindGameObjectWithTag("MegaMan");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(string s in listEnemy)
        {
            GameObject[] a;
            a = GameObject.FindGameObjectsWithTag(s);
            foreach(GameObject g in a)
            {
                if (player.transform.position.x < g.transform.position.x - 5)
                    g.SetActive(false);
                if (g.transform.position.x - 5 <= player.transform.position.x && player.transform.position.x <= g.transform.position.x)
                {
                    g.SetActive(true);
                }            
            }
        }
    }
}
