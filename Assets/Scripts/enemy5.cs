using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy5 : MonoBehaviour
{
    public Rigidbody2D rb;
    GameObject x ;

    void Start()
    {
	    x = GameObject.FindGameObjectWithTag("MegaMan");
        rb.velocity = -transform.right * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < x.transform.position.x)
        {
		    rb.constraints = RigidbodyConstraints2D.None;
		    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
	    }
    }
}
