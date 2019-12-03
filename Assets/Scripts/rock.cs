using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
    Object explosionRef;
    // Start is called before the first frame update
    void Start()
    {
        explosionRef = Resources.Load("explosion"); 
    }

    // Update is called once per frame
    void Break(){
        GameObject explosion = (GameObject)Instantiate(explosionRef, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D col){
        Invoke("Break", 2f);
    }
}
