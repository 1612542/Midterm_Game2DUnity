using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour
{
    GameObject x;
    Object fadeR;
    // Start is called before the first frame update
    void Start()
    {
        x = GameObject.FindGameObjectWithTag("MegaMan");
        if (x.gameObject.name== "x")
           fadeR = Resources.Load("xfade");
        else fadeR = Resources.Load("zfade");
    }

    // Update is called once per frame
    void fade()
    {
        x.GetComponent<Renderer>().enabled = false;
        GameObject b = (GameObject)Instantiate(fadeR, x.transform.position, x.transform.rotation);
    }
    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject == x){
            x.GetComponent<Animator>().Play("fadeout");
            Invoke("fade", 0.3f);
        }
    }
}
